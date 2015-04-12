using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase
{
    /// <summary>
    ///     Defines a contract SecurityState classes.
    /// </summary>
    public interface ISecurityState
    {
        /// <summary>
        ///     Reference to the <see cref="PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and perform actions.
        /// </summary>
        /// <param name="securityKey"></param>
        void EnterSecurityCode(string securityKey);

        /// <summary>
        ///     Signal the external agents about an occuring event.  
        /// </summary>
        void Alarm();
    }
}