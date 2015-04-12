using System.Collections.Generic;
using System.Linq;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class ListMediator : IMediator
    {
        public ListMediator()
        {
            Colleagues = new List<IColleague>();
        }

        public List<IColleague> Colleagues { get; private set; }

        /// <summary>
        ///     Registers a notifier in the dictionary.
        /// </summary>
        public void Register(IColleague colleagueToRegister)
        {
            if (Colleagues.Contains(colleagueToRegister))
            {
                return;
            }

            Colleagues.Add(colleagueToRegister);
        }

        public void Register(params IColleague[] colleagues)
        {
            Colleagues.AddRange(colleagues.Where(colleague => !Colleagues.Contains(colleague)));
        }

        /// <summary>
        ///     Deploy a message to listeners from the deployer.
        /// </summary>
        /// <param name="messageDeployerColleague"></param>
        public void DeployMessage(IColleague messageDeployerColleague, string message)
        {
            foreach (var colleague in Colleagues)
            {
                if (colleague.Equals(messageDeployerColleague)) continue;
                colleague.ReceiveMessage(message);
            }
        }
    }
}