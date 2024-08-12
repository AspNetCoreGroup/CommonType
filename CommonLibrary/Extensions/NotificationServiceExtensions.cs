using CommonLibrary.Interfaces.Services;
using ModelLibrary.Enums;

namespace MonitoringCommonLibrary.Extensions
{
    public static class NotificationServiceExtensions
	{
		public static Task SendNotificationAsync(this INotificationService service)
		{
			return service.SendNotificationAsync(1, NotificationType.Test, new Dictionary<string, string>());
		}
    }
}