using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete;

namespace en.AndrewTorski.Byt.Third.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var securityCode = "1234";
            var masterCode = "4321";

            var mediator = new OneToManyMediatorDictionary();
            var regionMediator = new ListMediator();


            SecurityRegion  securityRegion1 = new SecurityRegion("RegionOne", mediator),
                            securityRegion2 = new SecurityRegion("RegionTwo", mediator);

            SecurityAgent   agent1 = new SecurityAgent("AgentOne", mediator, regionMediator),
                            agent2 = new SecurityAgent("AgentTwo", mediator, regionMediator),
                            agent3 = new SecurityAgent("AgentThree", mediator, regionMediator),
                            agent4 = new SecurityAgent("AgentFour", mediator, regionMediator),
                            agent5 = new SecurityAgent("AgentFive", mediator, regionMediator);

            mediator.Register(securityRegion1, agent1, agent2, agent3);
            mediator.Register(securityRegion2, agent4, agent5);

            regionMediator.Register(agent1, agent2, agent3);

            var watcher1 = new PremiseSecurityWatcher("WatcherOne", securityCode, masterCode, securityRegion1);
            
            //  watcher1's state defaults to Diasrmed upon creation. 
            //  Let's arm it.
            watcher1.EnterSecurityKey(securityCode);

            //  Now that it's in armed state. Let's alarm it and see what happens.
            watcher1.Alarm();
            agent1.SendMessage(string.Format("{0} requires backup!", agent1.Id));


            //  Now disarm it and change the state to Alarmed after disarming.
            watcher1.EnterSecurityKey(securityCode);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
