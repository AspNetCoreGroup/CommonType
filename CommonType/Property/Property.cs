using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeDevice.Property
{
    public class PropetryCollection
    {
        IEnumerable<Property>? Properties { get; set; }
    }

    public class Property
    {
        /// <summary>
        /// EventParameterType
        /// </summary>
        public string Name { get; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; } = string.Empty;
    }

    public enum PropertyType
    {
        SN,
        Address,
        DeviceType
    };

    public class DeviceType
    {
        static DeviceType() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 1, "Счетчик ЭЭ Миртек 1ф" },
        { 2, "Счетчик ЭЭ Миртек 3ф" },
        { 3, "Меркурий 203" },
        { 4, "Меркурий 230" },
        { 5, "Меркурий 234" },
        { 6, "РиМ 189" },
        { 6, "Милур 107" }
        };
    }
}
