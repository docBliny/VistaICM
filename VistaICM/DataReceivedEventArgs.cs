using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the DataReceived event of a SecurityModule.
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        #region Private fields

        private readonly byte[] _data;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataReceivedEventArgs class.
        /// </summary>
        /// <param name="data">The data bytes that were received.</param>
        /// <exception cref="ArgumentNullException">data cannot be null.</exception>
        public DataReceivedEventArgs(byte[] data)
        {
            if(data == null) { throw new ArgumentNullException("data"); }

            _data = data;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the data that was received.
        /// </summary>
        public byte[] GetData()
        {
            return _data;
        }

        #endregion
    }
}
