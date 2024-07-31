namespace CommonLibrary.Interfaces.Listeners
{
    public interface IMessageListener : IDisposable
    {
        void AddHandler(IMessageHandler messageHandler);

        void Open();
        void Close();
    }
}