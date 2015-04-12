using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class AlarmedAfterDisarmingState : ISecurityState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AlarmedAfterDisarmingState(PremiseSecurityWatcher premiseSecurityWatcher)
        {
            PremiseSecurityWatcher = premiseSecurityWatcher;
        }
        
        /// <summary>
        ///     Reference to the <see cref="ISecurityState.PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        public PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and check if it matches
        ///     Watcher's master security key. If it matches - Watcher will change it's state to Disarmed.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityCode(string securityKey)
        {
            Console.WriteLine("Agent entered security code: {0}", securityKey);
            if (PremiseSecurityWatcher.CompareMasterKey(securityKey))
            {
                Console.WriteLine("Master code matched.");
                PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.DisarmedState;
                return;
            }

            Console.WriteLine("Master code didn't match.");
        }

        /// <summary>
        ///     Signal the external agents that the system has been disarmed and awaits for the
        ///     external Security Code to be entered, so that it may change it's state to
        ///     disarmed.
        /// </summary>
        public void Alarm()
        {
            Console.Write("Premise: {0}: ", PremiseSecurityWatcher.Id);
            Console.WriteLine("Alarmed launched during heightend-awarness state.");

        }
    }
}