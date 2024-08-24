namespace CommonTypeDevice.RMQMessages
{
    public class DeviceMessage
    {
        public int DeviceId { get; set; }
        public string SerialNumber { get; set; } = "";

        public string DeviceType { get; set; } = "";

        public string NetAddress { get; set; } = "";
    }
}
