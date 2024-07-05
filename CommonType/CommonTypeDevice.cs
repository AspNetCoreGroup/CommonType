using CommonTypeDevice.Event;
using CommonTypeDevice.Measurument;
using CommonTypeDevice.Property;

namespace CommonTypeDevice
{
    public class DeviceData
    {
        public PropetryCollection PropetryCollection { set; get; } = new PropetryCollection();
        public List<DeviceEvent>? DeviceEvents { set; get; }
        public List<Measurement>? Registers { set; get; }
    }

   
    

   
}
