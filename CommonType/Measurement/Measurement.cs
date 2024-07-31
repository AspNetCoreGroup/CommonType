using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeDevice.Measurument
{
    public class Measurement
    {
        /// <summary>
        /// A+ A- .. 
        /// </summary>
        public string LogicalName { set; get; } = string.Empty;

        public double Value { set; get; }
        /// <summary>
        /// ват вар  UnitType
        /// </summary>
        public uint Unit { set; get; }
        public DateTime DateTime { set; get; }
    }

    public class UnitType
    {
        static UnitType() { }

        public static readonly Dictionary<uint, string> dictionary = new()
        {
        { 1, "В" },
        { 2, "А" },
        { 3, "Вт*ч" },
        { 4, "Вт*ч" }
        };
    }
}
