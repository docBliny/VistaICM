using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// A base class for data listener implementations.
    /// </summary>
    public abstract class Listener : Component
    {
        #region Protected fields

        private Container Components;

        #endregion

        #region Public events

        /// <summary>
        /// Occurs when data is received.
        /// </summary>
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Listener class.
        /// </summary>
        protected Listener()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the Listener class.
        /// </summary>
        /// <param name="container"></param>
        protected Listener(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Begins listening for data packets.
        /// </summary>
        public abstract void BeginListen();

        /// <summary>
        /// Stops listening for data packets.
        /// </summary>
        public abstract void EndListen();

        #endregion
        
        #region Protected methods

        /// <summary>
        /// Gets the component container, if any.
        /// </summary>
        protected Container Component { get; set; }

        #endregion

        #region Protected methods

        /// <summary>
        /// Releases the unmanaged resources used by the Component and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Components != null)
                {
                    this.Components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the DataReceived event.
        /// </summary>
        /// <param name="e"></param>
        protected void OnDataReceived(DataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                DataReceived(this, e);
            }  // if(DataReceived != null)
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        protected void InitializeComponent()
        {
            this.Components = new Container();
        }

        #endregion

    }
}
