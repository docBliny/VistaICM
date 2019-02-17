namespace Blinnikka.VistaIcm
{
    /// <summary>
    /// Enumerates the arming status states of the Vista ICM.
    /// </summary>
    public enum ArmStatus
    {
        /// <summary>
        /// The system is disarmed.
        /// </summary>
        Disarmed = 0,

        /// <summary>
        /// The system is armed in stay-mode.
        /// </summary>
        ArmedStay = 1,

        /// <summary>
        /// The system is armed is away-mode.
        /// </summary>
        ArmedAway = 2,
    }
}
