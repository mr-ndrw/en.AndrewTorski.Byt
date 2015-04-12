using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class DisarmedState : ISecurityState
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DisarmedState(PremiseSecurityWatcher premiseSecurityWatcher)
        {
            PremiseSecurityWatcher = premiseSecurityWatcher;
        }

        /// <summary>
        ///     Reference to the <see cref="PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        public PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and if the code matches
        ///     the Watcher's code - Arm the Watcher(change state to ArmedState). If not - do nothing.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityCode(string securityKey)
        {
            Console.WriteLine("Agent entered security code: {0}", securityKey);
            if (PremiseSecurityWatcher.CompareSecurityKey(securityKey))
            {
                Console.WriteLine("Code matched.");
                PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.ArmedState;
                return;
            }

            Console.WriteLine("Code didn't match.");
        }

        /// <summary>
        ///     Signal the external agents about an occuring event and change state to Silently Alarmed. 
        /// </summary>
        public void Alarm()
        {
            Console.Write("Premise: {0}: ", PremiseSecurityWatcher.Id);
            Console.WriteLine("Launching silent alarm...");
            PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.SilentlyAlarmedState;
            PremiseSecurityWatcher.SecurityRegion.SendMessage("Silent alarm launched in " + PremiseSecurityWatcher.Id);
        }
    }
}