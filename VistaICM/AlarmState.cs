namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Enumerates the alarm states of the Vista ICM.
    /// </summary>
    public enum AlarmState
    {
        /// <summary>
        /// An alarm has not been triggered.
        /// </summary>
        NoAlarm = 0,

        /// <summary>
        /// An alarm has been triggered.
        /// </summary>
        Alarm = 1,

        /// <summary>
        /// A fire alarm has been triggered.
        /// </summary>
        Fire = 2,
    }
}
