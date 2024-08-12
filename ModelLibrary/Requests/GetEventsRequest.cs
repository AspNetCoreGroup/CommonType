namespace ModelLibrary.Requests
{
    public class GetEventsRequest
    {
        public required int DeviceID { get; set; }

        public required DateTime MinDate { get; set; }

        public required DateTime MaxDate { get; set; }
    }
}