using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Blinnikka.VistaIcm;

namespace IcmDisplay
{
    public partial class frmConsole : Form
    {
        #region Private static fields

        private bool _verbose;
        private SecurityModule _securityModule;
        private List<ZoneInfo> _zoneInfos;

        #endregion

        #region Constructors

        public frmConsole()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods, event handlers

        private void Console_Load(object sender, EventArgs e)
        {
            _zoneInfos = new List<ZoneInfo>(16);
            _zoneInfos.AddRange(new[]
                                    {
                                        zoneInfo1, zoneInfo2, zoneInfo3, zoneInfo4, zoneInfo5, zoneInfo6, zoneInfo7,
                                        zoneInfo8, zoneInfo9, zoneInfo10, zoneInfo11, zoneInfo12, zoneInfo13, zoneInfo14,
                                        zoneInfo15, zoneInfo16
                                    });

            try
            {
                _securityModule = new SecurityModule();

                AddEventHandlers(_securityModule);

                _securityModule.Start();
            }
            catch (SocketException ex)
            {
                UdpListener udpListener;
                string errorMessage = ex.Message;

                if(_securityModule != null && _securityModule.Listener != null && _securityModule.Listener is UdpListener)
                {
                    udpListener = (UdpListener)_securityModule.Listener;
                    if(udpListener.EndPoint != null)
                    {
                        errorMessage = string.Format("IP: {0}\nPort: {1}\n\n{2}", udpListener.EndPoint.Address,
                                                     udpListener.EndPoint.Port, errorMessage);
                    }  // if(udpListener.EndPoint != null)
                }  // if have listener

                MessageBox.Show("Cannot set up a socket to listen to ICM data.\n\n" + errorMessage, "Network Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_securityModule != null)
            {
                RemoveEventHandlers(_securityModule);
                _securityModule.Stop();
            }
        }

        private void chkVerbose_CheckedChanged(object sender, EventArgs e)
        {
            _verbose = chkVerbose.Checked;
        }

        private void securityModule_AlarmStateChanged(object sender, EventArgs e)
        {
            WriteLine("Alarm state changed: " + (sender as SecurityModule).AlarmState);
        }

        private void securityModule_ArmStatusChanged(object sender, EventArgs e)
        {
            SetArmed();
            WriteLine("Arm status changed: " + (sender as SecurityModule).ArmStatus);
        }

        private void securityModule_CommandMessageReceived(object sender, CommandMessageReceivedEventArgs e)
        {
            if (_verbose)
            {
                WriteLine("Command message: " + e.Message);
            }  // if(_verbose)
        }

        private void securityModule_DiscoveryCompleted(object sender, EventArgs e)
        {
            SetArmed();
            SetReady();
            RefreshZones();
            WriteLine("Discovery completed.");
        }

        private void securityModule_DiscoveryMessageReceived(object sender, DiscoveryMessageReceivedEventArgs e)
        {
            if (_verbose)
            {
                WriteLine("Discovery message: " + e.Message);
            }  // if(_verbose)
        }

        private void securityModule_DisplayChanged(object sender, EventArgs e)
        {
            lblDisplay.Text = _securityModule.Display;

            if (_verbose)
            {
                WriteLine("Display: " + (sender as SecurityModule).Display);
            }  // if(_verbose)
        }

        private void securityModule_LowBattery(object sender, EventArgs e)
        {
            WriteLine("Low battery warning.");
        }

        private void securityModule_PowerFailure(object sender, EventArgs e)
        {
            WriteLine("Power failure.");
        }

        private void securityModule_PowerRestored(object sender, EventArgs e)
        {
            WriteLine("Power restored.");
        }

        private void securityModule_ReadyChanged(object sender, EventArgs e)
        {
            SetReady();
            WriteLine((sender as SecurityModule).Ready ? "Ready" : "Not ready");
        }

        private void securityModule_RefreshError(object sender, RefreshErrorEventArgs e)
        {
            string errorMessage = e.Exception.ToString();

            if(e.WebRequest != null)
            {
                errorMessage = string.Format("URI: {0}\n\n{1}", e.WebRequest.RequestUri, e.Exception);
            }

            WriteLine("Error refreshing: " + errorMessage);
        }

        private void securityModule_UnitInfoMessageReceived(object sender, UnitInfoMessageReceivedEventArgs e)
        {
            if (_verbose)
            {
                WriteLine("UnitInfo message: " + e.Message);
            }  // if(_verbose)
        }

        private void securityModule_VariableMessageReceived(object sender, VariableMessageReceivedEventArgs e)
        {
            if (_verbose)
            {
                WriteLine("Variable message: " + e.Message);
            }  // if(_verbose)
        }

        private void securityModule_ZoneChanged(object sender, ZoneChangedEventArgs e)
        {
            WriteLine("Zone changed: " + e.Zone);

            _zoneInfos[e.Zone.Id - 1].IsFaulted = e.Zone.IsFaulted;
            _zoneInfos[e.Zone.Id - 1].ZoneID = e.Zone.Id;
            _zoneInfos[e.Zone.Id - 1].ZoneName = e.Zone.Name;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        #endregion

        #region Private methods

        private void SetArmed()
        {
            ArmedLight.BackColor = _securityModule.ArmStatus == ArmStatus.Disarmed ? this.BackColor : Color.Red;
        }

        private void SetReady()
        {
            ReadyLight.BackColor = _securityModule.Ready ? Color.Green :this.BackColor;
        }

        private void RefreshZones()
        {
            foreach(Zone zone in _securityModule.Zones.Values)
            {
                _zoneInfos[zone.Id - 1].IsFaulted = zone.IsFaulted;
                _zoneInfos[zone.Id - 1].ZoneID = zone.Id;
                _zoneInfos[zone.Id - 1].ZoneName = zone.Name;
            }  // foreach
        }

        private void WriteLine(string text)
        {
            rtbLog.AppendText(text + Environment.NewLine);
        }

        private void AddEventHandlers(SecurityModule securityModule)
        {
            securityModule.AlarmStateChanged += securityModule_AlarmStateChanged;
            securityModule.ArmStatusChanged += securityModule_ArmStatusChanged;
            securityModule.CommandMessageReceived += securityModule_CommandMessageReceived;
            securityModule.DiscoveryCompleted += securityModule_DiscoveryCompleted;
            securityModule.DiscoveryMessageReceived += securityModule_DiscoveryMessageReceived;
            securityModule.DisplayChanged += securityModule_DisplayChanged;
            securityModule.LowBattery += securityModule_LowBattery;
            securityModule.PowerFailure += securityModule_PowerFailure;
            securityModule.PowerRestored += securityModule_PowerRestored;
            securityModule.ReadyChanged += securityModule_ReadyChanged;
            securityModule.RefreshError += securityModule_RefreshError;
            securityModule.UnitInfoMessageReceived += securityModule_UnitInfoMessageReceived;
            securityModule.VariableMessageReceived += securityModule_VariableMessageReceived;
            securityModule.ZoneChanged += securityModule_ZoneChanged;
        }

        private void RemoveEventHandlers(SecurityModule securityModule)
        {
            securityModule.AlarmStateChanged -= securityModule_AlarmStateChanged;
            securityModule.ArmStatusChanged -= securityModule_ArmStatusChanged;
            securityModule.CommandMessageReceived -= securityModule_CommandMessageReceived;
            securityModule.DiscoveryCompleted -= securityModule_DiscoveryCompleted;
            securityModule.DiscoveryMessageReceived -= securityModule_DiscoveryMessageReceived;
            securityModule.DisplayChanged -= securityModule_DisplayChanged;
            securityModule.LowBattery -= securityModule_LowBattery;
            securityModule.PowerFailure -= securityModule_PowerFailure;
            securityModule.PowerRestored -= securityModule_PowerRestored;
            securityModule.ReadyChanged -= securityModule_ReadyChanged;
            securityModule.UnitInfoMessageReceived -= securityModule_UnitInfoMessageReceived;
            securityModule.VariableMessageReceived -= securityModule_VariableMessageReceived;
            securityModule.ZoneChanged -= securityModule_ZoneChanged;
        }

        #endregion

    }
}
