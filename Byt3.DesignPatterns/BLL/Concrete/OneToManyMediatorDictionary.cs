using System.Collections.Generic;
using System.Linq;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    /// <summary>
    ///     
    /// </summary>
    public class OneToManyMediatorDictionary : IMediatorDictionary
    {
        /// <summary>
        ///     Initialize the Security Notifier.
        /// </summary>
        public OneToManyMediatorDictionary()
        {
            Dictionary = new Dictionary<IColleague, List<IColleague>>();
        }

        /// <summary>
        ///     Dictionary of associations between a Key Collague and a Value collection of Colleagues.
        /// </summary>
        public Dictionary<IColleague, List<IColleague>> Dictionary { get; private set; }

        /// <summary>
        ///     Register a value colleague
        /// </summary>
        /// <param name="keyColleague"></param>
        /// <param name="valueColleague"></param>
        public void Register(IColleague keyColleague, IColleague valueColleague)
        {
            //  First try registering the keyColleague
            Register(keyColleague);
            //  Then check if the list associated with key colleague already contains
            //  the value colleague. If it doesn't - add the value colleague.
            if (!Dictionary[keyColleague].Contains(valueColleague))
            {
                Dictionary[keyColleague].Add(valueColleague);
            }
        }

        public void Register(IColleague keyColleague, params IColleague[] valueColleagues)
        {
            Register(keyColleague);
            Dictionary[keyColleague].AddRange(valueColleagues.Where(valueColleague => !Dictionary[keyColleague].Contains(valueColleague)));
        }

        /// <summary>
        ///     Registers a notifier in the dictionary.
        /// </summary>
        public void Register(IColleague keyColleague)
        {
            if (Dictionary.ContainsKey(keyColleague))
            {
                return;
            }
            Dictionary.Add(keyColleague, new List<IColleague>());
        }

        /// <summary>
        ///     Deploy the message for the key colleague to it's value colleagues.
        /// </summary>
        public void DeployMessageFromKey(IColleague deployerColleague, string message)
        {
            Dictionary[deployerColleague].ForEach(colleague => colleague.ReceiveMessage(message));
        }

        /// <summary>
        ///     Deploy the message from value colleague to it's key colleague.
        /// </summary>
        public void DeployMessageFromValue(IColleague deployerColleague, string message)
        {
            //  Iterate through keys and check if their values - lists contain the deployerColleague.
            //  If they do - collect them and then send the message to them.

            (from pair in Dictionary
             let value = pair.Value
             let key = pair.Key
             where value.Contains(deployerColleague)
             select key)
                .ToList()
                .ForEach(colleague => colleague.ReceiveMessage(message));
        }
    }
}