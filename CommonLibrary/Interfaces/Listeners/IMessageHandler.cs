using ModelLibrary.Events;

namespace CommonLibrary.Interfaces.Listeners
{
    public interface IMessageHandler
    {
        void OnMessageRecieved(MessageRecievedEventArgs args);
    }
}