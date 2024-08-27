using ModelLibrary.Enums;

namespace ModelLibrary.Messages
{
    public class NotificationMessage
    {
        public int UserID { get; set; }
        public NotificationType NotificationsType { get; set; }
        public List<NotificationMessageParam>? Params { get; set; }
    }
}
