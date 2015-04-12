using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class SecurityAgent : IColleague
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public SecurityAgent(string id, IMediatorDictionary mediator, IMediator regionMediator)
        {
            Id = id;
            Mediator = mediator;
            RegionMediator = regionMediator;
        }

        /// <summary>
        ///     Unique identifier of the security agent.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Mediator dictionary with which the agent communicates.
        /// </summary>
        public IMediatorDictionary Mediator { get; private set; }

        public IMediator RegionMediator { get; private set; }

        public void ReceiveMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Security agent: {0} received the following message: {1}", Id, message);
            Console.ResetColor();

        }

        public void SendMessage(string message)
        {
            RegionMediator.DeployMessage(this, message);
        }


    }
}