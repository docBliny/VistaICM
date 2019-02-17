using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the UnitInfoMessageReceived event of a SecurityModule.
    /// </summary>
    public class UnitInfoMessageReceivedEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UnitInfoMessageReceivedEventArgs class.
        /// </summary>
        /// <param name="message">The value for the Message property.</param>
        /// <exception cref="ArgumentNullException">message cannot be null.</exception>
        public UnitInfoMessageReceivedEventArgs(UnitInfoMessage message)
        {
            if (message == null) { throw new ArgumentNullException("message"); }

            this.Message = message;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the message that was received.
        /// </summary>
        public UnitInfoMessage Message { get; private set; }

        #endregion
    }
}
