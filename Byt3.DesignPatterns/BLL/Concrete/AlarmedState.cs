using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class AlarmedState : ISecurityState
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AlarmedState"/> class.
        /// </summary>
        public AlarmedState(PremiseSecurityWatcher premiseSecurityWatcher)
        {
            PremiseSecurityWatcher = premiseSecurityWatcher;
        }

        /// <summary>
        ///     Reference to the <see cref="ISecurityState.PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        public PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and if the code matched
        ///     changes the state of the Watcher to AlarmedAfterDisarming.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityCode(string securityKey)
        {
            Console.WriteLine("Agent entered security code: {0}", securityKey);
            if (PremiseSecurityWatcher.CompareSecurityKey(securityKey))
            {
                Console.WriteLine("Code matched.");
                PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.AlarmedAfterDisarmingState;
                PremiseSecurityWatcher.SecurityRegion.SendMessage("Alarmed was deactivated in " + PremiseSecurityWatcher.Id);
                return;
            }

            Console.WriteLine("Code didn't match.");
        }

        /// <summary>
        ///     Signal the external agents about an occuring event. Does nothing really... 
        /// </summary>
        public void Alarm()
        {
            //  Nothing
        }
    }
}