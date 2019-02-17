using System;
using System.Net;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the RefreshError event of a SecurityModule.
    /// </summary>
    public class RefreshErrorEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RefreshErrorEventArgs class.
        /// </summary>
        /// <param name="exception">The value for the Exception property.</param>
        /// <param name="request">The value for the WebRequest property.</param>
        /// <exception cref="ArgumentNullException">exception cannot be null.</exception>
        public RefreshErrorEventArgs(Exception exception, WebRequest request)
        {
            if (exception == null) { throw new ArgumentNullException("exception"); }

            this.Exception = exception;
            this.WebRequest = request;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the exception that occurred.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the web request that was attempted, or <c>null</c> if not available.
        /// </summary>
        public WebRequest WebRequest { get; private set; }

        #endregion
    }
}
