using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Provides a strongly-typed version of a Vista ICM command message.
    /// </summary>
    public class CommandMessage
    {
        #region Private fields

        private string _name;
        private string _parameter1;
        private string _parameter2;
        private string _parameter3;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CommandMessage class.
        /// </summary>
        protected internal CommandMessage()
        {
            _name = string.Empty;
            this.Parameter1 = string.Empty;
            this.Parameter2 = string.Empty;
            this.Parameter3 = string.Empty;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the source name.
        /// </summary>
        /// <exception cref="ArgumentNullException">Name cannot be an empty string or null.</exception>
        public string Name
        {
            get { return _name; }

            protected internal set
            {
                if(string.IsNullOrEmpty(value)) { throw new ArgumentNullException("value"); }

                _name = value;
            }
        }

        /// <summary>
        /// Gets the first parameter, or an empty string if not set.
        /// </summary>
        /// <exception cref="ArgumentNullException">Parameter1 cannot be an empty string or null.</exception>
        public string Parameter1
        {
            get { return _parameter1; }
            protected internal set
            {
                if(value == null) { throw new ArgumentNullException("value"); }

                _parameter1 = value;
            }
        }

        /// <summary>
        /// Gets the second parameter, or an empty string if not set.
        /// </summary>
        /// <exception cref="ArgumentNullException">Parameter2 cannot be an empty string or null.</exception>
        public string Parameter2
        {
            get { return _parameter2; }
            protected internal set
            {
                if (value == null) { throw new ArgumentNullException("value"); }

                _parameter2 = value;
            }
        }

        /// <summary>
        /// Gets the third parameter, or an empty string if not set.
        /// </summary>
        /// <exception cref="ArgumentNullException">Parameter3 cannot be an empty string or null.</exception>
        public string Parameter3
        {
            get { return _parameter3; }
            protected internal set
            {
                if (value == null) { throw new ArgumentNullException("value"); }

                _parameter3 = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts this CommandMessage to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{Name='" + this.Name + "',Parameter1='" + this.Parameter1 + "',Parameter2='" + this.Parameter2 + "',Parameter3='" + this.Parameter1 + "'}";
        }

        #endregion
    }
}
