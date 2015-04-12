using System;
using en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.Concrete
{
    public class PremiseSecurityWatcher
    {
        #region Private Fields

        private readonly string _securityKey;
        private readonly string _masterSecurityKey;
        private ISecurityState _currentSecurityState;

        #endregion

        #region Constructors

        public PremiseSecurityWatcher(string id, string securityKey, string masterSecuritykey, SecurityRegion securityRegion)
        {
            _securityKey = securityKey;
            _masterSecurityKey = masterSecuritykey;

            DisarmedState = new DisarmedState(this);
            ArmedState = new ArmedState(this);
            AlarmedState = new AlarmedState(this);
            AlarmedAfterDisarmingState = new AlarmedAfterDisarmingState(this);
            SilentlyAlarmedState = new SilentlyAlarmedState(this);
            SecurityRegion = securityRegion;
            Id = id;

            //  Upon creation the Watcher's state is set to disarmed.
            _currentSecurityState = DisarmedState;
        } 

        #endregion

        #region Properties

        /// <summary>
        ///     Identifier of the premise.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        ///     Security Region to which the messages will be sent and which later will be
        ///     propagated to Security Agents.
        /// </summary>
        public SecurityRegion SecurityRegion { get; private set; }

        /// <summary>
        ///     Gets or sets the Current Security State in which the Watcher is
        ///     at the moment of calling.
        /// </summary>
        public ISecurityState CurrentSecurityState
        {
            get { return _currentSecurityState; }
            set
            {
                Console.WriteLine("Changing watcher state from {0} to {1}.", 
                    _currentSecurityState.GetType().Name, 
                    value.GetType().Name);

                _currentSecurityState = value;
            }
        }

        public ISecurityState DisarmedState { get; private set; }
        public ISecurityState ArmedState { get; private set; }
        public ISecurityState AlarmedState { get; private set; }
        public ISecurityState AlarmedAfterDisarmingState { get; private set; }
        public ISecurityState SilentlyAlarmedState { get; private set; } 

        #endregion

        #region Public Methods

        /// <summary>
        ///     Allows an agent to enter the key into Watcher, which depending on the state
        ///     the Watcher finds itself in, should result in different actions.
        /// </summary>
        /// <param name="securityKey"></param>
        public void EnterSecurityKey(string securityKey)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CurrentSecurityState.EnterSecurityCode(securityKey);
            Console.ResetColor();
        }

        /// <summary>
        ///     Sound the alarm.
        /// </summary>
        public void Alarm()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CurrentSecurityState.Alarm();
            Console.ResetColor();
        }

        /// <summary>
        ///     Compare the agent-provided key against the Watcher's key.
        /// </summary>
        /// <param name="securityKey">
        ///     Agent-provided security key.
        /// </param>
        /// <returns>
        ///     True if keys are the same; false otherwise.
        /// </returns>
        public bool CompareSecurityKey(string securityKey)
        {
            return _securityKey == securityKey;
        }

        /// <summary>
        ///     Compare the agent-provided master key against the Watcher's master key.
        /// </summary>
        /// <param name="masterKey">
        ///     Agent-provided master key.
        /// </param>
        /// <returns>
        ///     True if keys are the same; false otherwise.
        /// </returns>
        public bool CompareMasterKey(string masterKey)
        {
            return _masterSecurityKey == masterKey;
        }
        #endregion
    }
}