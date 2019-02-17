using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IcmDisplay
{
    public partial class ZoneInfo : UserControl
    {
        #region Private fields

        private int _zoneId;
        private bool _isFaulted;
        private string _zoneName;

        #endregion

        #region Constructors

        public ZoneInfo()
        {
            InitializeComponent();

            _zoneName = string.Empty;
            SetZoneNameLabel();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets whether the zone is currently in a faulted state.
        /// </summary>
        public bool IsFaulted
        {
            get { return _isFaulted; }
            set
            {
                _isFaulted = value;
                zoneFault.BackColor = _isFaulted ? Color.Red : Color.Green;
            }
        }

        /// <summary>
        /// Gets or sets the zone name.
        /// </summary>
        public string ZoneName
        {
            get { return _zoneName; }
            set
            {
                if(value == null) { throw new ArgumentNullException("value");}
                _zoneName = value;
                SetZoneNameLabel();
            }
        }

        /// <summary>
        /// Gets or sets the zone number.
        /// </summary>
        public int ZoneID
        {
            get { return _zoneId; }
            set
            {
                _zoneId = value;
                SetZoneNameLabel();
            }
        }

        #endregion

        #region Private methods

        private void SetZoneNameLabel()
        {
            if (_zoneName == string.Empty)
            {
                lblZoneName.Text = _zoneId == 0 ? string.Empty : string.Format("Zone {0}", _zoneId);
            }  // if (_zoneName == string.Empty)
            else
            {
                lblZoneName.Text = string.Format("{0}: {1}", _zoneId, _zoneName);
            }  // else
        }

        #endregion
    }
}
