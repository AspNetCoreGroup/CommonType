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
            var random = new Random((int)(DateTime.Now.Ticks / 1000000));

            var response = new GetMeasurementsResponse()
            {
                Measurements = Enumerable.Range(0, 100 + random.Next() % 100).Select(x =>
                    new ModelLibrary.Model.Devices.Measurument.Measurement()
                    {
                        DateTime = DateTime.Now,
                        LogicalName = "A+",
                        Unit = 1,
                        Value = random.Next() % 1000000
                    }
                ).ToList()
            };

            return Task.FromResult(response);
        }
    }
}