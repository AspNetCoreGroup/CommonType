using ModelLibrary.Enums;

namespace CommonLibrary.Interfaces.Services
{
    public interface IRequestsService
    {
        Task RequestAsync<T>(RequestType requestType, string path, T? request, CancellationToken cancellationToken);

        Task<V> RequestAsync<V, T>(RequestType requestType, string path, T? request, CancellationToken cancellationToken);
    }
}