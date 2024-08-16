using CommonTypeDevice.Event;
using CommonTypeDevice.MeasurumentData;
using CommonTypeDevice.Property;

namespace CommonTypeDevice
{
    public class DeviceData
    {
        public List<DeviceProperty>? Properties { get; set; } 
        public List<DeviceEvent>? DeviceEvents { set; get; }
        public List<MeasurementData>? Measurements { set; get; }
    }
}
