namespace ModelLibrary.Requests
{
    [Obsolete("Этот механизм на данный момент не реализован.")]
    public class GetEventsRequest
    {
        public required int DeviceID { get; set; }

        public required DateTime MinDate { get; set; }

        public required DateTime MaxDate { get; set; }
    }
}