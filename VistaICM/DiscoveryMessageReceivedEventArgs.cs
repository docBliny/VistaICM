using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the DiscoveryMessageReceived event of a SecurityModule.
    /// </summary>
    public class DiscoveryMessageReceivedEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DiscoveryMessageReceivedEventArgs class.
        /// </summary>
        /// <param name="message">The value for the Message property.</param>
        /// <exception cref="ArgumentNullException">message cannot be null.</exception>
        public DiscoveryMessageReceivedEventArgs(DiscoveryMessage message)
        {
            if (message == null) { throw new ArgumentNullException("message"); }

            this.Message = message;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the message that was received.
        /// </summary>
        public DiscoveryMessage Message { get; private set; }

        #endregion
    }
}
