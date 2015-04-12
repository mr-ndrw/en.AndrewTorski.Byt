using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class SecurityRegion : IColleague
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public SecurityRegion(string regionName, IMediatorDictionary mediator)
        {
            RegionName = regionName;
            Mediator = mediator;
        }

        public string RegionName { get; set; }

        public IMediatorDictionary Mediator { get; private set; }

        /// <summary>
        ///     Receive and print the message.
        /// </summary>
        /// <param name="message"></param>
        public void ReceiveMessage(string message)
        {
            Console.WriteLine("Region {0} received message: '{1}'", RegionName, message);
        }

        /// <summary>
        ///     Sends message through the mediator.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            Mediator.DeployMessageFromKey(this, message);
        }
    }
}