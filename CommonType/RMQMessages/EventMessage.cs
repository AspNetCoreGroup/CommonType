namespace CommonTypeDevice.RMQMessages
{
    public class EventMessage
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime Dt { get; set; }
        public int DeviceId { get; set; }        
        public string DeviceType { get; set; } = string.Empty;
        public string DeviceSerial { get; set; } = string.Empty;
    }
}
