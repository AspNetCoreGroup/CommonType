using CommonLibrary.Extensions;
using CommonLibrary.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using ModelLibrary.Model.Devices;
using ModelLibrary.Requests;
using ModelLibrary.Responses;

namespace DefaultRealisationLibrary.Services
{
    public class DataStorageService : IDataStorageService
    {
        private IRequestsService RequestsService { get; set; }

        private IConfiguration Configuration { get; set; }

        public DataStorageService(IRequestsService requestsService, IConfiguration configuration)
        {
            RequestsService = requestsService;
            Configuration = configuration;
        }

        [Obsolete]
        public async Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request)
        {
            var path = $"DataStorage/Events?deviceID={request.DeviceID}&minDate={request.MinDate}&maxDate={request.MaxDate}";

            return await RequestsService.GetAsync<GetEventsResponse>(path);
        }

        public async Task<GetMeasurementsResponse> GetMeasurementsAsync(GetMeasurementsRequest request)
        {
            var host = Configuration["Services:DataStorageService:Host"];
            var path = host + "/DataFromDevice/DeviceArchiveById";

            var list = await RequestsService.PostAsync<List<MeasurementData>, GetMeasurementsRequest>(path, request);

            return new GetMeasurementsResponse()
            {
                Measurements = list
            };
        }

        public async Task<List<MeasurumentIdDescription>> GetMeasurementsAsync()
        {
            var host = Configuration["Services:DataStorageService:Host"];
            var path = host + "/DataFromDevice/MeasurumentIdDescription";

            return await RequestsService.GetAsync<List<MeasurumentIdDescription>>(path);
        }
    }
}