using CommonLibrary.Interfaces.Senders;
using CommonLibrary.Interfaces.Services;
using ModelLibrary.Enums;

namespace DefaultRealisationLibrary.Services
{
    public class NotificationService : INotificationService
    {
        private IMessageSender MessageSender { get; set; }

        public NotificationService(IMessageSender messageSender)
        {
            MessageSender = messageSender;
        }

        public Task SendNotificationAsync(int userID, NotificationType notificationsType, Dictionary<string, string> additionalParams)
        {
            // TODO: Доделать
            return Task.CompletedTask;
        }
    }
}

