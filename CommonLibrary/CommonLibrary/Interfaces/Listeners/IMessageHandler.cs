namespace CommonLibrary.Interfaces.Listeners
{
    public interface IMessageHandler
    {
        void OnMessageRecieved(string queueName, string message, Dictionary<string, string> param);
    }
}