using ModelLibrary.Enums;

namespace CommonLibrary.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(int userID, NotificationType notificationsType, Dictionary<string, string> additionalParams);
    }
}