using System.Security.Cryptography.X509Certificates;

namespace en.AndrewTorski.Byt.Third.DesignPatterns.BLL.InterfaceAndBase
{
    public interface IColleague
    {
        /// <summary>
        ///     OneToManyMediatorDictionary with which the colleague communicates.
        /// </summary>
        IMediatorDictionary Mediator { get; }

        /// <summary>
        ///     Receive the message from the Mediator.
        /// </summary>
        /// <param name="message">
        ///     Received message.
        /// </param>
        void ReceiveMessage(string message);

        /// <summary>
        ///     Send the message to the mediator.
        /// </summary>
        /// <param name="message">
        ///     Message to send.
        /// </param>
        void SendMessage(string message);
    }
}