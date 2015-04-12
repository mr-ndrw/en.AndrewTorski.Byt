using System.Collections;
using System.Collections.Generic;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase
{
    public interface IMediator
    {
        /// <summary>
        ///     Registers a notifier in the dictionary.
        /// </summary>
        void Register(IColleague colleagueToRegister);

        /// <summary>
        ///     Deploy a message to listeners from the deployer.
        /// </summary>
        /// <param name="messageDeployerColleague"></param>
        void DeployMessage(IColleague messageDeployerColleague, string message);
    }
}