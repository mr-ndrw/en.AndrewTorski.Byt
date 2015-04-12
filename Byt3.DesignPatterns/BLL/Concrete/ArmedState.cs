using System;
using System.Runtime.InteropServices;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class ArmedState : ISecurityState
    {
        private short currentNumberOfTries;
        private short totalNumberOfTries;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ArmedState(PremiseSecurityWatcher premiseSecurityWatcher)
        {
            PremiseSecurityWatcher = premiseSecurityWatcher;
            currentNumberOfTries = 0;
            totalNumberOfTries = 2;
        }

        /// <summary>
        ///     Reference to the <see cref="ISecurityState.PremiseSecurityWatcher"/> which uses this Security State.
        /// </summary>
        public PremiseSecurityWatcher PremiseSecurityWatcher { get; set; }

        /// <summary>
        ///     Evaluate the security code provided by the external agent and if the code matches
        ///     with Watcher's code - change state to Disarmed. If for 3 consecutive attempts the 
        ///     agent still didn't provide correct code - change state to Alarmed and launch the 
        ///     alarm.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityCode(string securityKey)
        {
            Console.WriteLine("Agent entered security code: {0}", securityKey);
            if (!PremiseSecurityWatcher.CompareSecurityKey(securityKey))
            {
                Console.WriteLine("Code didn't match for {0} out {1} times.", currentNumberOfTries, totalNumberOfTries);
                if (currentNumberOfTries == totalNumberOfTries)
                {
                    Console.WriteLine("Code didn't match for {0} times.", totalNumberOfTries + 1);
                    PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.AlarmedState;
                    Alarm();
                    currentNumberOfTries = 0;
                    return;
                }
                currentNumberOfTries++;
            }
            else
            {
                Console.WriteLine("Code matched.");
                currentNumberOfTries = 0;
                PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.DisarmedState;
            }
        }

        /// <summary>
        ///     Signal the external agents about an occuring event and change the state. 
        /// </summary>
        public void Alarm()
        {
            Console.Write("Premise: {0}: ", PremiseSecurityWatcher.Id);
            Console.WriteLine("Alarm was launched.");
            PremiseSecurityWatcher.CurrentSecurityState = PremiseSecurityWatcher.AlarmedState;
            PremiseSecurityWatcher.SecurityRegion.SendMessage("Alarm was launched in " + PremiseSecurityWatcher.Id);
        }
    }
}