using ModelLibrary.Requests;
using ModelLibrary.Responses;

namespace CommonLibrary.Interfaces.Services
{
    public interface IDataStorageService
	{
        Task<GetMeasurementsResponse> GetMeasurementsAsync(GetMeasurementsRequest request);

        [Obsolete]
        Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request);
    }
}