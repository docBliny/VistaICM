using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides a strongly-typed version of a Vista ICM discovery message.
    /// </summary>
    public class DiscoveryMessage
    {
        #region Private fields

        private string _key;
        private string _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DiscoveryMessage class.
        /// </summary>
        protected internal DiscoveryMessage()
        {
            _key = string.Empty;
            this.Value = string.Empty;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the checksum value.
        /// </summary>
        public int Checksum { get; protected internal set; }

        /// <summary>
        /// Gets the associated variable name.
        /// </summary>
        /// <exception cref="ArgumentNullException">Key cannot be an empty string or null.</exception>
        public string Key
        {
            get { return _key; }
            protected internal set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("value", "Key cannot be an empty string or null."); }

                _key = value;
            }
        }

        /// <summary>
        /// Gets the IP address of the discovered device.
        /// </summary>
        public IPAddress IPAddress { get; protected internal set; }

        /// <summary>
        /// Gets the MAC address of the discovered device.
        /// </summary>
        public PhysicalAddress MacAddress { get; protected internal set; }

        /// <summary>
        /// Gets the value set for the associated variable.
        /// </summary>
        /// <exception cref="ArgumentNullException">Value cannot be null.</exception>
        public string Value
        {
            get { return _value; }
            protected internal set
            {
                if (value == null) { throw new ArgumentNullException("value"); }

                _value = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts this DiscoveryMessage to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{Checksum=" + this.Checksum + ",Key='" + this.Key + "',Value='" + this.Value + "',IPAddress=" + this.IPAddress + ",MacAddress=" + this.MacAddress + "}";
        }

        #endregion
    }
}
