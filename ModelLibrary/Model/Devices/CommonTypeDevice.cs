using ModelLibrary.Model.Devices.Event;
using ModelLibrary.Model.Devices.Measurument;
using ModelLibrary.Model.Devices.Property;

namespace ModelLibrary.Model.Devices
{
    public class DeviceData
    {
        public List<DeviceProperty>? Properties { get; set; } 
        public List<DeviceEvent>? DeviceEvents { set; get; }
        public List<Measurement>? Registers { set; get; }
    }
}
