namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase
{
    /// <summary>
    ///     Defines a contract for mediator dictionary of any configuration.
    /// </summary>
    public interface IMediatorDictionary
    {
        void DeployMessageFromKey(IColleague deployerColleague, string message);
        void DeployMessageFromValue(IColleague deployerColleague, string message);
        void Register(IColleague keyColleague, IColleague valueColleague);
        void Register(IColleague keyColleague);
    }
}