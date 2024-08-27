namespace ModelLibrary.Requests
{
    public class GraphRequestWrapper
    {
        public int? NetworkID { get; set; }

        public int? DeviceID { get; set; }

        public DateTime MinDateTime { get; set; }

        public DateTime MaxDateTime { get; set; }
    }
}