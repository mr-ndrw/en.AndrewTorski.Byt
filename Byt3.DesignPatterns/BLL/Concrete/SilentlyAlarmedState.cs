using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class SilentlyAlarmedState : ISecurityState
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public SilentlyAlarmedState(PremiseSecurityWatcher premiseSecurityWatcher)
        {
            PremiseSecurityWatcher = premiseSecurityWatcher;
        }

        /// <summary>
        ///     Reference to the <see cref="ISecurityState.PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        public PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and on successful match with
        ///     Watcher's code changes the state to AlarmedAfterDisarming.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityCode(string securityKey)
        {
            Console.WriteLine("Agent entered security code: {0}", securityKey);
            if (PremiseSecurityWatcher.CompareSecurityKey(securityKey))
            {
                Console.WriteLine("Code matched.");
                PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.AlarmedAfterDisarmingState;
                return;
            }

            Console.WriteLine("Code didn't match.");

        }

        /// <summary>
        ///     Signal the external agents about an occuring event. Silently...  
        /// </summary>
        public void Alarm()
        {
            Console.Write("Premise: {0}: ", PremiseSecurityWatcher.Id);
            Console.WriteLine("Silently alarming...");
            PremiseSecurityWatcher.SecurityRegion.SendMessage("Silent alarm in " + PremiseSecurityWatcher.Id);
        }
    }
}