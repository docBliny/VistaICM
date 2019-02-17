using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides a strongly-typed version of a Vista ICM unit info message.
    /// </summary>
    public class UnitInfoMessage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UnitInfoMessage class.
        /// </summary>
        protected internal UnitInfoMessage()
        {
            this.Variables = new SortedList<string, string>();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the checksum value.
        /// </summary>
        public int Checksum { get; protected internal set; }

        /// <summary>
        /// Gets the IP address of the discovered device.
        /// </summary>
        public IPAddress IPAddress { get; protected internal set; }

        /// <summary>
        /// Gets the MAC address of the discovered device.
        /// </summary>
        public PhysicalAddress MacAddress { get; protected internal set; }

        /// <summary>
        /// Gets the unit number.
        /// </summary>
        public int Number { get; protected internal set; }

        /// <summary>
        /// Gets the list variables as key/value pairs.
        /// </summary>
        public SortedList<string, string> Variables { get; internal set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts this UnitInfoMessage to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{Checksum=" + this.Checksum + ",IPAddress=" + this.IPAddress + ",MacAddress=" + this.MacAddress + ",Number=" + this.Number + ",Variables=" + this.Variables + "}";
        }

        #endregion
    }
}
