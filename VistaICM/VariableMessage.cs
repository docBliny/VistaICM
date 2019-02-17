using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides a strongly-typed version of a Vista ICM variable message.
    /// </summary>
    public class VariableMessage
    {
        #region Private fields

        private string _key;
        private string _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VariableMessage class.
        /// </summary>
        protected internal VariableMessage()
        {
            _key = string.Empty;
            this.Value = string.Empty;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the variable name that was set.
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
        /// Gets the Node number this variable applies to.
        /// </summary>
        public int Node { get; protected internal set; }

        /// <summary>
        /// Gets the Unit number this variable applies to.
        /// </summary>
        public int Unit { get; protected internal set; }

        /// <summary>
        /// Gets the value set for the variable.
        /// <exception cref="ArgumentNullException">Value cannot be null.</exception>
        /// </summary>
        public string Value
        {
            get { return _value; }
            protected internal set
            {
                if (value == null) { throw new ArgumentNullException("value", "Value cannot be null."); }

                _value = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts this VariableMessage to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{Key='" + this.Key + "',Value='" + this.Value + "',Node=" + this.Node + ",Unit=" + this.Unit + "}";
        }

        #endregion
    }
}
