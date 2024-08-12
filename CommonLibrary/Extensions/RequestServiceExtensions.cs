using CommonLibrary.Interfaces.Services;
using ModelLibrary.Enums;

namespace CommonLibrary.Extensions
{
    public static class RequestServiceExtensions
	{
        public static Task<V> GetAsync<V>(this IRequestsService service, string path, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<V, object>(RequestType.Get, path, null, cancellationToken);
        }

        public static Task<V> PostAsync<V, T>(this IRequestsService service, string path, T? request, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<V, T>(RequestType.Post, path, request, cancellationToken);
        }

        public static Task<V> PostAsync<V>(this IRequestsService service, string path, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<V, object>(RequestType.Post, path, default, cancellationToken);
        }

        public static Task PostAsync<T>(this IRequestsService service, string path, T? request, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync(RequestType.Post, path, request, cancellationToken);
        }

        public static Task PostAsync(this IRequestsService service, string path, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<object>(RequestType.Post, path, null, cancellationToken);
        }

        public static Task<V> PutAsync<V, T>(this IRequestsService service, string path, T? request, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<V, T>(RequestType.Put, path, request, cancellationToken);
        }

        public static Task PutAsync<T>(this IRequestsService service, string path, T? request, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync(RequestType.Put, path, request, cancellationToken);
        }

        public static Task DeleteAsync(this IRequestsService service, string path, CancellationToken cancellationToken = default)
        {
            return service.RequestAsync<object>(RequestType.Delete, path, null, cancellationToken);
        }
    }
}