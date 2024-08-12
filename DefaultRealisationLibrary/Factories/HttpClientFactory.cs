using CommonLibrary.Interfaces.Factories;

namespace DefaultRealisationLibrary.Factories
{
	public class HttpClientFactory : IHttpClientFactory /* TODO: Поправить на System.NET! */, IDisposable
    {
        private HttpClient HttpClient { get; set; }

        public HttpClientFactory()
        {
            HttpClient = new HttpClient();
        }

        public HttpClient GetHttpClient()
        {
            return HttpClient;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}