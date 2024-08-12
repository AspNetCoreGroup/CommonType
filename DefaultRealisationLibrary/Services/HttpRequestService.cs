﻿using System.Text.Json;
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

            var content = CreateHttpContent(request);

            var response = await SendRequestAsync(requestType, path, content, cancellationToken);

            response.EnsureSuccessStatusCode();
        }

        public async Task<V> RequestAsync<V, T>(RequestType requestType, string path, T? request, CancellationToken cancellationToken)
        {
            ValidateRequest(requestType, path, request);

            var content = CreateHttpContent(request);

            var response = await SendRequestAsync(requestType, path, content, cancellationToken);

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

        private static StringContent? CreateHttpContent<T>(T? request)
        {
            if (request == null)
            {
                return null;
            }

            var str = JsonSerializer.Serialize(request);

            var httpContent = new StringContent(str);

            return httpContent;
        }

        private static async Task<T> ParseHttpResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken) ?? throw new Exception($"Запрос вернул пустой ответ.");

            return JsonSerializer.Deserialize<T>(responseString) ?? throw new Exception("Ошибка десериализации ответа");
        }

        private Task<HttpResponseMessage> SendRequestAsync(RequestType requestType, string path, HttpContent? content, CancellationToken cancellationToken)
        {
            return requestType switch
            {
                RequestType.Get => Client.GetAsync(path, cancellationToken),
                RequestType.Post => Client.PostAsync(path, content, cancellationToken),
                RequestType.Put => Client.PutAsync(path, content, cancellationToken),
                RequestType.Delete => Client.DeleteAsync(path, cancellationToken),
                _ => throw new Exception(""),
            };
        }
    }
}