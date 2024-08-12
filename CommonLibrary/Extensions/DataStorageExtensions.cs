using CommonLibrary.Interfaces.Services;
using ModelLibrary.Requests;
using ModelLibrary.Responses;

namespace CommonLibrary.Extensions
{
    public static class DataStorageExtensions
	{
        public static Task<GetMeasurementsResponse> GetMeasurementsAsync(this IDataStorageService service, int deviceID, DateTime minDate, DateTime maxDate)
        {
            var request = new GetMeasurementsRequest()
            {
                DeviceID = deviceID,
                MinDate = minDate,
                MaxDate = maxDate
            };

            return service.GetMeasurementsAsync(request);
        }

        public static Task<GetEventsResponse> GetEventsAsync(this IDataStorageService service, int deviceID, DateTime minDate, DateTime maxDate)
        {
            var request = new GetEventsRequest()
            {
                DeviceID = deviceID,
                MinDate = minDate,
                MaxDate = maxDate
            };

            return service.GetEventsAsync(request);
        }
    }
}