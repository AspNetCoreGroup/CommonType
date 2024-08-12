using CommonLibrary.Extensions;
using CommonLibrary.Interfaces.Services;
using ModelLibrary.Requests;
using ModelLibrary.Responses;

namespace DefaultRealisationLibrary.Services
{
    public class DataStorageService : IDataStorageService
    {
        private IRequestsService RequestsService { get; set; }


        public DataStorageService(IRequestsService requestsService)
        {
            RequestsService = requestsService;
        }

        public async Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request)
        {
            var path = $"DataStorage/Events?deviceID={request.DeviceID}&minDate={request.MinDate}&maxDate={request.MaxDate}";

            return await RequestsService.GetAsync<GetEventsResponse>(path);
        }

        public async Task<GetMeasurementsResponse> GetMeasurementsAsync(GetMeasurementsRequest request)
        {
            var path = $"DataStorage/Measurements?deviceID={request.DeviceID}&minDate={request.MinDate}&maxDate={request.MaxDate}";

            return await RequestsService.GetAsync<GetMeasurementsResponse>(path);
        }
    }
}