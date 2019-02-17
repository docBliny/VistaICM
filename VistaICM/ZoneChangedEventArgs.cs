using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides data for the ZoneChanged event of a SecurityModule.
    /// </summary>
    public class ZoneChangedEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VariableMessageReceivedEventArgs class.
        /// </summary>
        /// <param name="zone">The value for the Zone property.</param>
        /// <exception cref="ArgumentNullException">zone cannot be null.</exception>
        public ZoneChangedEventArgs(Zone zone)
        {
            if (zone == null) { throw new ArgumentNullException("zone"); }

            this.Zone = zone;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the zone that was modified.
        /// </summary>
        public Zone Zone { get; private set; }

        #endregion
    }
}
