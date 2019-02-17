using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the VariableMessageReceived event of a SecurityModule.
    /// </summary>
    public class VariableMessageReceivedEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VariableMessageReceivedEventArgs class.
        /// </summary>
        /// <param name="message">The value for the Message property.</param>
        /// <exception cref="ArgumentNullException">message cannot be null.</exception>
        public VariableMessageReceivedEventArgs(VariableMessage message)
        {
            if (message == null) { throw new ArgumentNullException("message"); }

            this.Message = message;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the message that was received.
        /// </summary>
        public VariableMessage Message { get; private set; }

        #endregion
    }
}
