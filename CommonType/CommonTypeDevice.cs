using CommonTypeDevice.Event;
using CommonTypeDevice.Measurument;
using CommonTypeDevice.Property;

namespace CommonTypeDevice
{
    public class DeviceData
    {
        public List<DeviceProperty>? Properties { get; set; } 
        public List<DeviceEvent>? DeviceEvents { set; get; }
        public List<Measurement>? Registers { set; get; }
    }
}
