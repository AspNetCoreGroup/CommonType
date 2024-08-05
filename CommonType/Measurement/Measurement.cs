namespace CommonTypeDevice.Measurument
{
    public class Measurement
    {
        /// <summary>
        /// A+ A- .. 
        /// </summary>
        public int MeasurumentId { set; get; }

        public double Value { set; get; }
        /// <summary>
        /// ват вар  UnitType
        /// </summary>
        public uint Unit { set; get; }
        public DateTime DateTime { set; get; }
    }
    public class MeasurementDictionary
    {

        static MeasurementDictionary() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 1, "A+" },
        { 2, "A-" },
        { 3, "R+" },
        { 4, "R-" }

        };
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
