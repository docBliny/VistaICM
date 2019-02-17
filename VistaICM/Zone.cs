using System;

namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Represents a Vista ICM security zone and its status.
    /// </summary>
    public class Zone
    {
        #region Private fields

        private int _id;
        private bool _isFaulted;
        private string _name;

        #endregion

        #region Public events

        /// <summary>
        /// Occurs when the zone's IsFaulted property changes.
        /// </summary>
        public event EventHandler<EventArgs> IsFaultedChanged;

        /// <summary>
        /// Occurs when the zone's name changes.
        /// </summary>
        public event EventHandler<EventArgs> NameChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Zone class.
        /// </summary>
        protected internal Zone()
        {
            this.Name = string.Empty;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the zone number.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The zone ID must be a value between 1 and 16.</exception>
        public int Id
        {
            get { return _id; }
            protected internal set
            {
                if (value <= 0 || value > 16) { throw new ArgumentOutOfRangeException("value", "The zone ID must be a value between 1 and 16."); }
                _id = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the zone is currently in a fault state.
        /// </summary>
        public bool IsFaulted
        {
            get { return _isFaulted; }
            protected internal set
            {
                if(_isFaulted != value)
                {
                    _isFaulted = value;
                    OnIsFaultedChanged();
                }  // if(_isFaulted != value)
            }
        }

        /// <summary>
        /// Gets the name of the zone. The name may not be available immediately.
        /// </summary>
        /// <exception cref="ArgumentNullException">Name cannot be null.</exception>
        public string Name
        {
            get { return _name; }
            protected internal set
            {
                if (value == null) { throw new ArgumentNullException("value"); }

                if (_name != value)
                {
                    _name = value;
                    OnNameChanged();
                }  // if(_name != value)
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts this Zone to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{Id=" + this.Id + ",Name='" + this.Name + "',IsFaulted=" + this.IsFaulted + "}";
        }

        #endregion
        #region Protected methods

        /// <summary>
        /// Raises the IsFaultedChanged event.
        /// </summary>
        protected void OnIsFaultedChanged()
        {
            if (IsFaultedChanged != null)
            {
                IsFaultedChanged(this, new EventArgs());
            }  // if(IsFaultedChanged != null)
        }

        /// <summary>
        /// Raises the NameChanged event.
        /// </summary>
        protected void OnNameChanged()
        {
            if (NameChanged != null)
            {
                NameChanged(this, new EventArgs());
            }  // if(NameChanged != null)
        }

        #endregion

    }
}
