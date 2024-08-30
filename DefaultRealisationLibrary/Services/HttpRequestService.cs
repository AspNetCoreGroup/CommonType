using System.Text.Json;
using System.Net.Http.Json;
using CommonLibrary.Interfaces.Factories;
using CommonLibrary.Interfaces.Services;
using ModelLibrary.Enums;

namespace DefaultRealisationLibrary.Services
{
    public class HttpRequestService : IRequestsService
    {
        private HttpClient Client { get; set; }

        public HttpRequestService(IHttpClientFactory httpClientFactory)
        {
            Client = httpClientFactory.GetHttpClient();
        }

        public async Task RequestAsync<T>(RequestType requestType, string path, T? request, CancellationToken cancellationToken)
        {
            ValidateRequest(requestType, path, request);

            var response = await SendRequestAsync(requestType, path, request, cancellationToken);

            response.EnsureSuccessStatusCode();
        }

        public async Task<V> RequestAsync<V, T>(RequestType requestType, string path, T? request, CancellationToken cancellationToken)
        {
            ValidateRequest(requestType, path, request);

            var response = await SendRequestAsync(requestType, path, request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await ParseHttpResponseAsync<V>(response, cancellationToken);
        }

        private static void ValidateRequest<T>(RequestType requestType, string path, T? request)
        {
            if ((requestType == RequestType.Get || requestType == RequestType.Delete) && request != null)
            {
                throw new Exception("Запрос данного типа не может содержать тело.");
            }
        }

        private static async Task<T> ParseHttpResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken) ?? throw new Exception($"Запрос вернул пустой ответ.");

            return JsonSerializer.Deserialize<T>(responseString) ?? throw new Exception("Ошибка десериализации ответа");
        }

        private Task<HttpResponseMessage> SendRequestAsync<T>(RequestType requestType, string path, T? value, CancellationToken cancellationToken)
        {
            if (value == null)
            {
                return requestType switch
                {
                    RequestType.Get => Client.GetAsync(path, cancellationToken),
                    RequestType.Post => Client.PostAsync(path,null, cancellationToken),
                    RequestType.Put => Client.PutAsync(path, null, cancellationToken),
                    RequestType.Delete => Client.DeleteAsync(path, cancellationToken),
                    _ => throw new Exception(""),
                };
            }
            else
            {
                return requestType switch
                {
                    RequestType.Get => Client.GetAsync(path, cancellationToken),
                    RequestType.Post => Client.PostAsJsonAsync(path, value, cancellationToken),
                    RequestType.Put => Client.PostAsJsonAsync(path, value, cancellationToken),
                    RequestType.Delete => Client.DeleteAsync(path, cancellationToken),
                    _ => throw new Exception(""),
                };
            }
        }
    }
}