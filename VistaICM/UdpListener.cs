using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading; 

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// A listener implementation that receives data packets from a Vista ICM.
    /// </summary>
    public class UdpListener : Listener
    {
        #region Private constants

        private const int DefaultPort = 3947;

        #endregion

        #region Private fields

        private IPAddress _ipAddress;
        private int _port = DefaultPort;

        private UdpClient _socket;

        private bool _isListening;

        private SendOrPostCallback OnDataReceivedDelegate;

        private delegate void WorkerEventHandler(AsyncOperation asyncOp);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UdpListener class.
        /// </summary>
        public UdpListener()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class that listens on the given UDP port.
        /// </summary>
        /// <param name="port">Port to listen on.</param>
        public UdpListener(int port)
        {
            _port = port;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class that listens on the given UDP port from the specified IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address to listen to.</param>
        public UdpListener(IPAddress ipAddress)
        {
            if (ipAddress == null) { throw new ArgumentNullException("ipAddress"); }

            _ipAddress = ipAddress;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class that listens on the given UDP port from the specified IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address to listen to.</param>
        /// <param name="port">Port to listen on.</param>
        public UdpListener(IPAddress ipAddress, int port)
        {
            if (ipAddress == null) { throw new ArgumentNullException("ipAddress"); }

            _ipAddress = ipAddress;
            _port = port;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class.
        /// </summary>
        /// <param name="container"></param>
        public UdpListener(IContainer container)
            : base(container)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class that listens on the given UDP port.
        /// </summary>
        /// <param name="port">Port to listen on.</param>
        /// <param name="container"></param>
        public UdpListener(int port, IContainer container)
            : base(container)
        {
            _port = port;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the UdpListener class that listens on the given UDP port from the specified IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address to listen to.</param>
        /// <param name="port">Port to listen on.</param>
        /// <param name="container"></param>
        public UdpListener(IPAddress ipAddress, int port, IContainer container)
            : base(container)
        {
            if (ipAddress == null) { throw new ArgumentNullException("ipAddress"); }

            _ipAddress = ipAddress;
            _port = port;
            Initialize();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the IPEndPoint used by this listener.
        /// </summary>
        public IPEndPoint EndPoint { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Releases the unmanaged resources used by the Component and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_socket != null)
                {
                    _socket.Close();

                    _socket = null;
                } // if(_socket != null)

                if (this.EndPoint != null)
                {
                    this.EndPoint = null;
                } // if(this.EndPoint != null)
            }  // if (disposing)

            base.Dispose(disposing);
        }

        /// <summary>
        /// Begins listening for data packets.
        /// </summary>
        public override void BeginListen()
        {
            if (_isListening)
            {
                throw new InvalidOperationException("Already listening.");
            }

            this.EndPoint = new IPEndPoint(IPAddress.Any, _port);
            _socket = new UdpClient(this.EndPoint) { EnableBroadcast = true };

            AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(this);

            WorkerEventHandler worker = new WorkerEventHandler(Listen);

            _isListening = true;
            worker.BeginInvoke(asyncOperation, null, null);
        }

        /// <summary>
        /// Stops listening for data packets.
        /// </summary>
        public override void EndListen()
        {
            _isListening = false;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the component and creates internal objects.
        /// </summary>
        private void Initialize()
        {
            OnDataReceivedDelegate = new SendOrPostCallback(RaiseDataReceived);
        }

        /// <summary>
        /// Listens to data received on the UDP port and transfers the received data packets to the originating thread.
        /// </summary>
        /// <param name="asyncOperation"></param>
        private void Listen(AsyncOperation asyncOperation)
        {
            DataReceivedEventArgs e;
            IPEndPoint remoteHost = null;

            while (_isListening)
            {
                try
                {
                    byte[] data = _socket.Receive(ref remoteHost);

                    // Check to see if we wanted a specific source and whether data came from there
                    if(_ipAddress == null || (_ipAddress.Equals(remoteHost.Address)))
                    {
                        // Raise the DataReceived event on the calling thread
                        e = new DataReceivedEventArgs(data);
                        asyncOperation.Post(OnDataReceivedDelegate, e);
                    }  // if(_ipAddress == null || (_ipAddress.Equals(remoteHost)))

                }
                catch(Exception ex)
                {
                    // TODO: Add "Completed" event
                    Debug.WriteLine(ex.ToString());
                }
            }  // while(_isListening)
        }

        /// <summary>
        /// Method invoked via the AsyncOperation object to pass data to listeners, thus it is guaranteed to be executed on the correct thread.
        /// 
        /// NOTE: This is not true for console applications! This method will be running on a thread pool thread in this case!
        /// 
        /// </summary>
        /// <param name="state">An instance of the DataReceivedEventArgs object that contains the received data.</param>
        private void RaiseDataReceived(object state)
        {
            DataReceivedEventArgs e = state as DataReceivedEventArgs;

            // Raise the event
            OnDataReceived(e);
        }

        #endregion
    }
}
