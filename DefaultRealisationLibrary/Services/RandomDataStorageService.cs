using CommonLibrary.Interfaces.Services;
using ModelLibrary.Requests;
using ModelLibrary.Responses;

namespace DefaultRealisationLibrary.Services
{
    public class RandomDataStorageService : IDataStorageService
    {
        private Random Random { get; set; }

        public RandomDataStorageService()
        {
            Random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
        }

        public Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request)
        {
            var response = new GetEventsResponse()
            {
                
            };

            return Task.FromResult(response);
        }

        public Task<GetMeasurementsResponse> GetMeasurementsAsync(GetMeasurementsRequest request)
        {
            var response = new GetMeasurementsResponse()
            {

            };

            return Task.FromResult(response);
        }
    }
}