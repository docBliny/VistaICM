using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides status, events and information about a Vista ICM security module.
    /// </summary>
    public class SecurityModule
    {
        #region Private constants

        private const int DefaultRefreshInterval = 5000;
        private const int DefaultRequestTimeout = 2000;

        #endregion

        #region Private fields

        private SortedList<int, Zone> _zones;

        private bool _isInitialUnitInfoMessage;
        private int _refreshInterval;

        private AlarmState _alarmState;
        private ArmStatus _armStatus;
        private bool _ready;
        private string _displayText;

        private Timer _tmrRefresh;

        #endregion

        #region Public events

        /// <summary>
        /// Occurs when the device's AlarmState property changes.
        /// </summary>
        public event EventHandler<EventArgs> AlarmStateChanged;

        /// <summary>
        /// Occurs when the device's ArmStatus property changes.
        /// </summary>
        public event EventHandler<EventArgs> ArmStatusChanged;

        /// <summary>
        /// Occurs when a command message is received.
        /// </summary>
        public event EventHandler<CommandMessageReceivedEventArgs> CommandMessageReceived;

        /// <summary>
        /// Occurs when the first auto-discovery message has been received and processed when no IP address was specified.
        /// </summary>
        public event EventHandler<EventArgs> DiscoveryCompleted;

        /// <summary>
        /// Occurs when a discovery message is received.
        /// </summary>
        public event EventHandler<DiscoveryMessageReceivedEventArgs> DiscoveryMessageReceived;

        /// <summary>
        /// Occurs when the device's display text changes. This usually happens every second, rotating between the two lines of text displayed on the alarm panel.
        /// </summary>
        public event EventHandler<EventArgs> DisplayChanged;

        /// <summary>
        /// Occurs when the device issues a low battery warning.
        /// </summary>
        public event EventHandler<EventArgs> LowBattery;

        /// <summary>
        /// Occurs when the device loses AC power.
        /// </summary>
        public event EventHandler<EventArgs> PowerFailure;

        /// <summary>
        /// Occurs when the device's AC power is restored.
        /// </summary>
        public event EventHandler<EventArgs> PowerRestored;

        /// <summary>
        /// Occurs when the device's Ready property changes.
        /// </summary>
        public event EventHandler<EventArgs> ReadyChanged;

        /// <summary>
        /// Occurs when the an error occurs when sending a refresh request to the device.
        /// </summary>
        public event EventHandler<RefreshErrorEventArgs> RefreshError;

        /// <summary>
        /// Occurs when a unit info message is received.
        /// </summary>
        public event EventHandler<UnitInfoMessageReceivedEventArgs> UnitInfoMessageReceived;

        /// <summary>
        /// Occurs when a variable message is received.
        /// </summary>
        public event EventHandler<VariableMessageReceivedEventArgs> VariableMessageReceived;

        /// <summary>
        /// Occurs when a zone's name or state changes.
        /// </summary>
        public event EventHandler<ZoneChangedEventArgs> ZoneChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SecurityModule class with a default UDP listener.
        /// </summary>
        public SecurityModule()
        {
            Initialize(new UdpListener());
        }

        /// <summary>
        /// Initializes a new instance of the SecurityModule class with a default UDP listener and the given IP address.
        /// </summary>
        /// <param name="ipAddress">IP address of the Vista ICM.</param>
        /// <exception cref="ArgumentNullException">ipAddress cannot be null.</exception>
        public SecurityModule(IPAddress ipAddress)
        {
            if(ipAddress == null) { throw new ArgumentNullException("ipAddress");}

            IPAddress = ipAddress;
            Initialize(new UdpListener(IPAddress));
        }

        /// <summary>
        /// Initializes a new instance of the SecurityModule class with the given listener.
        /// </summary>
        /// <param name="listener">A listener class to use to listen for data.</param>
        /// <exception cref="ArgumentNullException">listener cannot be null.</exception>
        public SecurityModule(Listener listener)
        {
            if(listener == null) { throw new ArgumentNullException("listener");}

            Initialize(listener);
        }

        /// <summary>
        /// Initializes a new instance of the SecurityModule class with the given listener and IP address.
        /// </summary>
        /// <param name="ipAddress">IP address of the Vista ICM.</param>
        /// <param name="listener">A listener class to use to listen for data.</param>
        /// <exception cref="ArgumentNullException">ipAddress cannot be null.</exception>
        /// <exception cref="ArgumentNullException">listener cannot be null.</exception>
        public SecurityModule(IPAddress ipAddress, Listener listener)
        {
            if (ipAddress == null) { throw new ArgumentNullException("ipAddress"); }
            if (listener == null) { throw new ArgumentNullException("listener"); }

            IPAddress = ipAddress;
            Initialize(listener);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the current alarm state.
        /// </summary>
        public AlarmState AlarmState
        {
            get { return _alarmState; }
            private set
            {
                if(_alarmState != value)
                {
                    _alarmState = value;
                    OnAlarmStateChanged();
                }  // if(_alarmState != value)
            }
        }

        /// <summary>
        /// Gets the current arm status.
        /// </summary>
        public ArmStatus ArmStatus
        {
            get { return _armStatus; }
            private set
            {
                if(_armStatus != value)
                {
                    _armStatus = value;
                    OnArmStatusChanged();
                }  // if(_armStatus != value)
            }
        }

        /// <summary>
        /// Gets the currently displayed text line. The contents of this property will alternate between line 1 and line 2 every second.
        /// </summary>
        public string Display
        {
            get { return _displayText; }
            private set
            {
                if(_displayText != value)
                {
                    _displayText = value;
                    OnDisplayChanged();
                }  // if(_displayText != value)
            }
        }

        /// <summary>
        /// Gets the ECP keybus ID assigned to the device. Valid values are between 16 - 23. This may not be available immediately and will return zero.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the IP address of the ICM.
        /// </summary>
        public IPAddress IPAddress { get; private set; }

        /// <summary>
        /// Gets the MAC address of the ICM.
        /// </summary>
        public PhysicalAddress MacAddress { get; private set; }

        /// <summary>
        /// Gets the data listener object.
        /// </summary>
        public Listener Listener { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the system is in a Ready state.
        /// </summary>
        public bool Ready
        {
            get { return _ready;  }
            private set
            {
                if(_ready != value)
                {
                    _ready = value;

                    OnReadyChanged();

                    // We also need to refresh since zone updates are stopped for 30 seconds after a change
                    // This will allow us the get to known state faster when the last fault goes away
                    if(this.IPAddress != null)
                    {
                        Refresh();
                    }
                }  // if(_ready != value)
            }
        }

        /// <summary>
        /// Gets or sets the interval to force the ICM to send a status update.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">RefreshInterval cannot be zero or less.</exception>
        public int RefreshInterval
        {
            get { return _refreshInterval; }
            set
            {
                if(value <= 0 ) { throw new ArgumentOutOfRangeException("value", "RefreshInterval cannot be zero or less.");}

                if(_refreshInterval != value)
                {
                    _refreshInterval = value;
                    _tmrRefresh.Interval = _refreshInterval;
                }  // if(_refreshInterval != value)
            }
        }

        /// <summary>
        /// Gets the zones.
        /// </summary>
        public SortedList<int, Zone> Zones
        {
            get { return new SortedList<int, Zone>(_zones); }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Releases the unmanaged resources used by the object and optionally releases the managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Listener != null)
                {
                    this.Listener.Dispose();
                    this.Listener = null;
                }  // if (this.Listener != null)
            }  // if (disposing)
        }

        /// <summary>
        /// Attempts to refresh the known status.
        /// </summary>
        /// <exception cref="InvalidOperationException">ICM discovery hasn't completed and no IP address was specified.</exception>
        public void Refresh()
        {
            bool sendError;
            HttpWebRequest request = null;

            // We may get called from a different thread from the timer
            if (IPAddress == null) { throw new InvalidOperationException("ICM discovery hasn't completed and no IP address was specified."); }

            // Send Refresh command to device.
            try
            {
                request = (HttpWebRequest)WebRequest.Create(new Uri(string.Format(CultureInfo.InvariantCulture, "http://{0}/cmd?cmd=(0.1.1)Refresh", IPAddress)));
                request.KeepAlive = false;
                request.Timeout = DefaultRequestTimeout;
                request.GetResponse();
            }
            catch (Exception ex)
            {
                sendError = true;
                if(ex is WebException)
                {
                    WebException wex = (WebException)ex;

                    // Ignore known exceptions. We're going to get:
                    // "System.Net.WebException: The server committed a protocol violation. Section=ResponseHeader Detail=CR must be followed by LF"
                    // because the .NET framework requires strictly formatted headers which the ICM doesn't provide. Send everything else
                    if(wex.Status == WebExceptionStatus.ServerProtocolViolation)
                    {
                        sendError = false;
                    }
                }

                if(sendError)
                {
                    OnRefreshError(ex, request);
                }  // if(sendError)
            }
        }

        /// <summary>
        /// Starts listening for updated from the ICM.
        /// </summary>
        public void Start()
        {
            this.Listener.BeginListen();
            _tmrRefresh.Start();
        }

        /// <summary>
        /// Stops listening for updates from the ICM.
        /// </summary>
        public void Stop()
        {
            this.Listener.EndListen();
            _tmrRefresh.Stop();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Raises the AlarmStateChanged event.
        /// </summary>
        protected void OnAlarmStateChanged()
        {
            if (AlarmStateChanged != null)
            {
                AlarmStateChanged(this, new EventArgs());
            }  // if(AlarmStateChanged != null)
        }

        /// <summary>
        /// Raises the ArmStatusChanged event.
        /// </summary>
        protected void OnArmStatusChanged()
        {
            if(ArmStatusChanged != null)
            {
                ArmStatusChanged(this, new EventArgs());
            }  // if(ArmStatusChanged != null)
        }

        /// <summary>
        /// Raises the CommandMessageReceived event.
        /// </summary>
        /// <param name="message">Message data object.</param>
        protected void OnCommandMessageReceived(CommandMessage message)
        {
            if (CommandMessageReceived != null)
            {
                CommandMessageReceived(this, new CommandMessageReceivedEventArgs(message));
            }  // if(DiscoveryMessageReceived != null)
        }

        /// <summary>
        /// Raises the DiscoveryCompleted event.
        /// </summary>
        protected void OnDiscoveryCompleted()
        {
            if (DiscoveryCompleted != null)
            {
                DiscoveryCompleted(this, new EventArgs());
            }  // if(DiscoveryCompleted != null)
        }

        /// <summary>
        /// Raises the DiscoveryMessageReceived event.
        /// </summary>
        /// <param name="message">Message data object.</param>
        protected void OnDiscoveryMessageReceived(DiscoveryMessage message)
        {
            if (DiscoveryMessageReceived != null)
            {
                DiscoveryMessageReceived(this, new DiscoveryMessageReceivedEventArgs(message));
            }  // if(DiscoveryMessageReceived != null)
        }

        /// <summary>
        /// Raises the DisplayChanged event.
        /// </summary>
        protected void OnDisplayChanged()
        {
            if(DisplayChanged != null)
            {
                DisplayChanged(this, new EventArgs());
            }  // if(DisplayChanged != null)
        }

        /// <summary>
        /// Raises the LowBattery event.
        /// </summary>
        protected void OnLowBattery()
        {
            if (LowBattery != null)
            {
                LowBattery(this, new EventArgs());
            }  // if(LowBattery != null)
        }

        /// <summary>
        /// Raises the PowerFailure event.
        /// </summary>
        protected void OnPowerFailure()
        {
            if (PowerFailure != null)
            {
                PowerFailure(this, new EventArgs());
            }  // if(PowerFailure != null)
        }

        /// <summary>
        /// Raises the PowerRestored event.
        /// </summary>
        protected void OnPowerRestored()
        {
            if (PowerRestored != null)
            {
                PowerRestored(this, new EventArgs());
            }  // if(PowerRestored != null)
        }

        /// <summary>
        /// Raises the ReadyChanged event.
        /// </summary>
        protected void OnReadyChanged()
        {
            if (ReadyChanged != null)
            {
                ReadyChanged(this, new EventArgs());
            }  // if (ReadyChanged != null)
        }

        /// <summary>
        /// Raises the RefreshError event.
        /// </summary>
        /// <param name="exception">The exception that occurred.</param>
        /// <param name="request">The attempted request.</param>
        protected void OnRefreshError(Exception exception, WebRequest request)
        {
            if (RefreshError != null)
            {
                RefreshError(this, new RefreshErrorEventArgs(exception, request));
            }  // if(RefreshError != null)
        }

        /// <summary>
        /// Raises the UnitInfoMessageReceived event.
        /// </summary>
        /// <param name="message">Message data object.</param>
        protected void OnUnitInfoMessageReceived(UnitInfoMessage message)
        {
            if (UnitInfoMessageReceived != null)
            {
                UnitInfoMessageReceived(this, new UnitInfoMessageReceivedEventArgs(message));
            }  // if(UnitInfoMessageReceived != null)
        }

        /// <summary>
        /// Raises the VariableMessageReceived event.
        /// </summary>
        /// <param name="message">Message data object.</param>
        protected void OnVariableMessageReceived(VariableMessage message)
        {
            if(VariableMessageReceived != null)
            {
                VariableMessageReceived(this, new VariableMessageReceivedEventArgs(message));
            }  // if(VariableMessageReceived != null)
        }

        /// <summary>
        /// Raises the ZoneChanged event.
        /// </summary>
        /// <param name="zone">The zone that was modified.</param>
        protected void OnZoneChanged(Zone zone)
        {
            if (ZoneChanged != null)
            {
                ZoneChanged(this, new ZoneChangedEventArgs(zone));
            }  // if(ZoneChanged != null)
        }

        #endregion

        #region Private methods, event handlers

        /// <summary>
        /// Handles DataReceived events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _listener_DataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] data = e.GetData();

            if(data != null)
            {
                //DumpPacket(data);

                // Process known messages
                if(data.Length >= 4)
                {
                    if (data[0] == 0x01 && data[1] == 0x03)
                    {
                        ProcessDiscoveryPacket(data);
                    }  // 0x01, 0x03
                    else if (data[0] == 0x01 && data[1] == 0x04)
                    {
                        ProcessUnitInfoPacket(data);
                    }  // 0x01, 0x04
                    else if (data[0] == 0x02 && data[1] == 0x04)
                    {
                        ProcessVariablePacket(data);
                    }  // 0x02, 0x04
                    else if(data[0] == 0x04 && data[1] == 0x01)
                    {
                        ProcessCommandPacket(data);
                    }  // 0x04, 0x01
                    else
                    {
                        // Unknown packet type
                        DumpPacket(data);
                    }  // else
                }  // if(data.Length >= 4)
            }  // if(data != null)
        }

        /// <summary>
        /// Handles refresh timer tick events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrRefresh_Elapsed(object sender, ElapsedEventArgs e)
        {
            // NOTE: On a different thread!
            Refresh();
        }

        /// <summary>
        /// Handles IsFaultedChanged events from zones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zone_IsFaultedChanged(object sender, EventArgs e)
        {
            OnZoneChanged(sender as Zone);
        }

        /// <summary>
        /// Handles NameChanged events from zones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zone_NameChanged(object sender, EventArgs e)
        {
            OnZoneChanged(sender as Zone);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the initial state.
        /// </summary>
        private void Initialize(Listener listener)
        {
            Zone zone;

            _displayText = string.Empty;
            _isInitialUnitInfoMessage = true;

            // Create zone list
            _zones = new SortedList<int, Zone>(16);
            for (int index = 0; index < 16; index += 1)
            {
                zone = new Zone {Id = (index + 1)};
                zone.IsFaultedChanged += zone_IsFaultedChanged;
                zone.NameChanged += zone_NameChanged;
                _zones.Add(index, zone);
            }

            // Create a refresh timer
            _refreshInterval = DefaultRefreshInterval;
            _tmrRefresh = new Timer
                              {
                                  //SynchronizingObject = ((ISynchronizeInvoke)_listener),
                                  Interval = _refreshInterval
                              };
            _tmrRefresh.Elapsed += _tmrRefresh_Elapsed;

            // Set listener
            this.Listener = listener;
            this.Listener.DataReceived += _listener_DataReceived;
        }

        /// <summary>
        /// Processes a received data packet that contains a command received by the ICM.
        /// </summary>
        /// <param name="data"></param>
        private void ProcessCommandPacket(byte[] data)
        {
            CommandMessage message;
            int length;
            string dataString;
            Regex regexParse;

            // Check for minimum valid data length
            if (data.Length >= 8)
            {
                // Check the data length
                length = ToUInt16(data, 6);

                // Make sure the data packet actually has this amount of data
                if (data.Length == length + 8)
                {
                    // Get the contained text
                    dataString = Encoding.ASCII.GetString(data, 8, length);

                    // Parse out the data and create a new message object
                    try
                    {
                        regexParse = new Regex(@"cmd=\(0\.0\.0\)_T_(?<Name>\w+):(?<Parameter1>[^()\x00]+)(?:\((?:(?<Parameter2>[^,\x00]+),(?<Parameter3>[^\x00]+)|(?<Parameter2>[^\x00]+))\))?");
                        message = new CommandMessage
                        {
                            Name = regexParse.Match(dataString).Groups["Name"].Value,
                            Parameter1 = regexParse.Match(dataString).Groups["Parameter1"].Value,
                            Parameter2 = regexParse.Match(dataString).Groups["Parameter2"].Value,
                            Parameter3 = regexParse.Match(dataString).Groups["Parameter3"].Value,
                        };

                        // Process the message internally for data we need
                        ProcessCommandMessage(message);

                        // Raise an event
                        OnCommandMessageReceived(message);
                    }  // try
                    catch (ArgumentException)
                    {
                        // Syntax error in the regular expression
                    }  // catch
                }  // if(data.Length == length + 8)
            }  // if(data.Length >= 8)
        }

        /// <summary>
        /// Processes a received data packet that contains the ICM network information.
        /// </summary>
        /// <param name="data"></param>
        private void ProcessDiscoveryPacket(byte[] data)
        {
            DiscoveryMessage message;
            Int32 ipTemp;
            IPAddress ipAddress;
            PhysicalAddress macAddress;
            int length;
            string dataString;
            string key = String.Empty;
            string value = null;

            // Check for minimum valid data length
            if (data.Length >= 34)
            {
                try
                {
                    ipTemp = BitConverter.ToInt32(data, 20);
                    ipAddress = new IPAddress(ipTemp);
                    byte[] mac = {data[28], data[29], data[30], data[31], data[32]};
                    macAddress = new PhysicalAddress(mac);

                    // Get the data length
                    length = ToUInt16(data, 12);

                    // Make sure the data packet actually has this amount of data
                    if (data.Length == length + 52)
                    {
                        // Get the contained text
                        dataString = Encoding.ASCII.GetString(data, 52, length);

                        if(dataString.Contains("="))
                        {
                            key = dataString.Substring(0, dataString.IndexOf("=", StringComparison.Ordinal));
                            value = dataString.Substring(dataString.IndexOf("=", StringComparison.Ordinal) + 1);
                            if (value.Contains("\n"))
                            {
                                value = value.Remove(value.IndexOf("\n", StringComparison.Ordinal));
                            }
                        }  // if(dataString.Contains("="))

                        message = new DiscoveryMessage
                                      {
                                          IPAddress = ipAddress,
                                          MacAddress = macAddress,
                                          Checksum = ToUInt16(data, 8),
                                          Key = key,
                                          Value = value
                                      };

                        // Process the message internally for data we need
                        ProcessDiscoveryMessage(message);

                        // Raise an event
                        OnDiscoveryMessageReceived(message);
                    }  // if (data.Length == length + 52)
                }  // try
                catch (Exception ex)
                {
                    Debug.WriteLine("ProcessDiscoveryPacket(): " + ex, "SecurityModule");
                }  // catch
            }  // if (data.Length >= 34)
        }

        private void ProcessUnitInfoPacket(byte[] data)
        {
            UnitInfoMessage message;
            Int32 ipTemp;
            IPAddress ipAddress;
            PhysicalAddress macAddress;
            int length;
            string dataString;
            string[] rawVariables;
            string key;
            string value;
            SortedList<string, string> variables = new SortedList<string, string>();

            // Check for minimum valid data length
            if (data.Length >= 48)
            {
                try
                {
                    ipTemp = BitConverter.ToInt32(data, 20);
                    ipAddress = new IPAddress(ipTemp);
                    byte[] mac = { data[28], data[29], data[30], data[31], data[32] };
                    macAddress = new PhysicalAddress(mac);

                    // Get the data length
                    length = ToUInt16(data, 12);

                    // Make sure the data packet actually has this amount of data
                    if (data.Length == length + 52)
                    {
                        // Get the contained text
                        dataString = Encoding.ASCII.GetString(data, 52, length);

                        // Split into an array
                        rawVariables = dataString.Split((char)0x0A);

                        foreach (string item in rawVariables)
                        {
                            if (item.Contains("="))
                            {
                                key = item.Substring(0, item.IndexOf("=", StringComparison.Ordinal));
                                value = item.Substring(item.IndexOf("=", StringComparison.Ordinal) + 1);
                                variables.Add(key, value);
                            }  // if(dataString.Contains("="))

                        } // foreach item

                        message = new UnitInfoMessage
                        {
                            IPAddress = ipAddress,
                            MacAddress = macAddress,
                            Checksum = ToUInt16(data, 8),
                            Variables = variables
                        };

                        // Process the message internally for data we need
                        ProcessUnitInfoMessage(message);

                        // Raise an event
                        OnUnitInfoMessageReceived(message);
                    }  // if (data.Length == length + 52)
                }  // try
                catch (Exception ex)
                {
                    Debug.WriteLine("ProcessUnitInfoPacket(): " + ex, "SecurityModule");
                }  // catch
            }  // if (data.Length >= 48)
        }

        /// <summary>
        /// Processes a received data packet that contains a variable.
        /// </summary>
        /// <param name="data"></param>
        private void ProcessVariablePacket(byte[] data)
        {
            VariableMessage message;
            int length;
            string dataString;
            string node;
            string unit;
            string key;
            string value;
            Regex regexParse;

            // Check for minimum valid data length
            if(data.Length >= 8)
            {
                // Check the data length
                length = ToUInt16(data, 6);

                // Make sure the data packet actually has this amount of data
                if(data.Length == length + 8)
                {
                    // Get the contained text
                    dataString = Encoding.ASCII.GetString(data, 8, length);

                    // Parse out the data and create a new message object
                    try
                    {
                        regexParse = new Regex(@"(?<Node>\d+)\.(?<Unit>\d+)\.(?<Key>[.\w]+)=(?<Value>[^\x00]*)");

                        node = regexParse.Match(dataString).Groups["Node"].Value;
                        unit = regexParse.Match(dataString).Groups["Unit"].Value;
                        key = regexParse.Match(dataString).Groups["Key"].Value;
                        value = regexParse.Match(dataString).Groups["Value"].Value;
                        if (string.IsNullOrEmpty(node) == false && string.IsNullOrEmpty(unit) == false)
                        {
                            message = new VariableMessage
                                          {
                                              Node = int.Parse(node, CultureInfo.InvariantCulture),
                                              Unit = int.Parse(unit, CultureInfo.InvariantCulture),
                                              Key = key,
                                              Value = value ?? String.Empty
                                          };

                            // Process the message internally for data we need
                            ProcessVariableMessage(message);

                            // Raise an event
                            OnVariableMessageReceived(message);
                        }  // if (string.IsNullOrEmpty(node) == false && string.IsNullOrEmpty(unit) == false)
                    }  // try
                    catch (ArgumentException)
                    {
                        // Syntax error in the regular expression
                    }  // catch
                }  // if(data.Length == length + 8)
            }  // if(data.Length >= 10)
        }

        /// <summary>
        /// Parses a VariableMessage for any data we wish to expose as properties or use as state data.
        /// </summary>
        /// <param name="message"></param>
        private void ProcessCommandMessage(CommandMessage message)
        {
            if(message.Name == "Security")
            {
                switch(message.Parameter1)
                {
                    case "Alarm":
                        this.AlarmState = AlarmState.Alarm;
                        break;
                    case "Armed Away":
                        this.ArmStatus = ArmStatus.ArmedAway;
                        break;
                    case "Armed Stay":
                        this.ArmStatus = ArmStatus.ArmedStay;
                        break;
                    case "Disarmed":
                        this.ArmStatus = ArmStatus.Disarmed;
                        break;
                    case "Fire":
                        this.AlarmState = AlarmState.Fire;
                        break;
                    case "Low Battery":
                        OnLowBattery();
                        break;
                    case "Power Failure":
                        OnPowerFailure();
                        break;
                    case "Power Returned":
                        OnPowerRestored();
                        break;
                }  // switch
            }  // if(message.Name == "Security")
        }

        /// <summary>
        /// Check if we've already got an IP address, and if not, parse a DiscoveryMessage IP-address.
        /// </summary>
        /// <param name="message"></param>
        private void ProcessDiscoveryMessage(DiscoveryMessage message)
        {
            if(IPAddress == null)
            {
                // Set the IP address
                this.IPAddress = message.IPAddress;
                this.MacAddress = message.MacAddress;

                if(IPAddress != null)
                {
                    // Request ICM status update
                    Refresh();

                    OnDiscoveryCompleted();

                    // Start updating
                    _tmrRefresh.Start();
                }  // if(_ipAddress != null)
            }  // if(_ipAddress == null)
        }

        /// <summary>
        /// Parses a UnitInfoMessage for any zone data.
        /// </summary>
        /// <param name="message"></param>
        private void ProcessUnitInfoMessage(UnitInfoMessage message)
        {
            SortedList<string, string> variables = message.Variables;
            Regex regexParse;
            string match;
            int zoneId;
            Zone zone;

           // Check if we need get zone names
            if(_isInitialUnitInfoMessage && variables != null)
            {
                _isInitialUnitInfoMessage = false;

                // Check if this message pertains to security
                if(variables.ContainsKey("name") && variables["name"] == "Security")
                {
                    regexParse = new Regex(@"T\.(?<Zone>(?:[2-9]|1[0-6]|1))");

                    // Loop for all zone names
                    foreach (string key in variables.Keys)
                    {
                        match = regexParse.Match(key).Groups["Zone"].Value;

                        if (int.TryParse(match, out zoneId))
                        {
                            zone = _zones[zoneId - 1];
                            zone.Name = variables[key];
                        }
                    }  // for each
                }  // if name == Security
            }  // if(variables != null)
        }

        /// <summary>
        /// Parses a VariableMessage for any data we wish to expose as properties or use as state data.
        /// </summary>
        /// <param name="message">The message to process.</param>
        private void ProcessVariableMessage(VariableMessage message)
        {
            // Check for Zone Status variable
            if (message.Key.StartsWith("ZS", StringComparison.Ordinal))
            {
                SetZoneStatus(message.Key, message.Value);
            }  // if(message.Key.StartsWith("ZS"))
            else
            {
                switch (message.Key)
                {
                    case "AlarmEvent":
                        SetAlarmEvent(message.Value);
                        break;
                    case "ArmStatus":
                        SetArmStatus(message.Value);
                        break;
                    case "display":
                        this.Display = message.Value;
                        break;
                    case "FireEvent":
                        SetFireEvent(message.Value);
                        break;
                    case "ID":
                        if(message.Value != null)
                        {
                            Id = int.Parse(message.Value, CultureInfo.InvariantCulture);
                        }  // if(message.Value != null)
                        break;
                    case "Ready":
                        SetReady(message.Value);
                        break;
                }  // switch
            }  // else
        }

        /// <summary>
        /// Updates the value of the AlarmState property based on a value received as a variable.
        /// </summary>
        /// <param name="value">The variable value.</param>
        private void SetAlarmEvent(string value)
        {
            int count;

            if(int.TryParse(value, out count))
            {
                this.AlarmState = (count == 0 ? AlarmState.NoAlarm : AlarmState.Alarm);
            }  // if(int.TryParse(value, out count))
        }

        /// <summary>
        /// Updates the value of the Alarm property based on a value received as a variable.
        /// </summary>
        /// <param name="value">The variable value.</param>
        private void SetArmStatus(string value)
        {
            switch (value)
            {
                case "0":
                    this.ArmStatus = ArmStatus.Disarmed;
                    break;
                case "1":
                    this.ArmStatus = ArmStatus.ArmedStay;
                    break;
                case "2":
                    this.ArmStatus = ArmStatus.ArmedAway;
                    break;
            }  // switch
        }

        /// <summary>
        /// Updates the value of the AlarmState property based on a value received as a variable.
        /// </summary>
        /// <param name="value">The variable value.</param>
        private void SetFireEvent(string value)
        {
            int count;

            if (int.TryParse(value, out count))
            {
                this.AlarmState = (count == 0 ? AlarmState.NoAlarm : AlarmState.Fire);
            }  // if(int.TryParse(value, out count))
        }

        /// <summary>
        /// Updates the zone status based on the given key/value pair.
        /// </summary>
        /// <param name="key">Key containing the "ZS" variable.</param>
        /// <param name="value">The variable value.</param>
        private void SetZoneStatus(string key, string value)
        {
            string match;
            Regex regexParse;
            int zoneId;
            Zone zone;

            try
            {
                // Parse out the zone number
                regexParse = new Regex(@"ZS\.(?<Zone>(?:[2-9]|1[0-6]|1))\z");
                match = regexParse.Match(key).Groups["Zone"].Value;

                if (match != null)
                {
                    if (int.TryParse(match, out zoneId))
                    {
                        zone = _zones[zoneId - 1];
                        switch (value)
                        {
                            case "0":
                                zone.IsFaulted = false;
                                break;
                            case "1":
                            case "2":
                                zone.IsFaulted = true;
                                break;
                        }  // switch
                    }  // if(int.TryParse(match, out zoneId))
                }  // if(match != null)
            }  // try
            catch (ArgumentException)
            {
                // Syntax error in the regular expression
            }  // catch
        }

        /// <summary>
        /// Updates the value of the Ready property based on a value received as a variable.
        /// </summary>
        /// <param name="value">The variable value.</param>
        private void SetReady(string value)
        {
            switch (value)
            {
                case "0":
                    this.Ready = false;
                    break;
                case "1":
                    this.Ready = true;
                    break;
            } // switch
        }

        private static UInt16 ToUInt16(byte[] data, int index)
        {
            // Switch to little endian
            byte[] value = { data[index + 1], data[index] };

            return BitConverter.ToUInt16(value, 0);
        }

        private static void DumpPacket(byte[] data)
        {
            var output = new StringBuilder();
            var output2 = new StringBuilder();

            // DEBUG: Dump the data
            foreach (byte dataByte in data)
            {
                output.Append(string.Format(CultureInfo.InvariantCulture, "0x0{0:X1},", dataByte));

                if (dataByte != 0)
                {
                    output2.Append(Encoding.ASCII.GetString(new[] { dataByte }));
                }
            }  // for each

            Debug.WriteLine(output.ToString());
            Debug.WriteLine(output2.ToString());
        }

        #endregion
    }
}
