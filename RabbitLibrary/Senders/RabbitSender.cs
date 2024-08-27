using CommonLibrary.Interfaces.Senders;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace RabbitLibrary.Senders
{
    public class RabbitSender : IMessageSender
    {
        #region Поля

        private IConfiguration Configuration { get; }

        #endregion

        public RabbitSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task SendMessageAsync(string endpoint, string message, Dictionary<string, string>? param = null)
        {
            var endpointConf = Configuration.GetSection($"Senders:RabbitMQ:Endpoints:{endpoint}");

            var hostName = endpointConf["HostName"] ?? throw new NullReferenceException($"Для {endpoint} не указан HostName");
            var virtualHost = endpointConf["VirtualHost"] ?? throw new NullReferenceException($"Для {endpoint} не указан VirtualHost");
            var userName = endpointConf["UserName"] ?? throw new NullReferenceException($"Для {endpoint} не указан UserName");
            var password = endpointConf["Password"] ?? throw new NullReferenceException($"Для {endpoint} не указан Password");
            var queue = endpointConf["Queue"];
            var exchange = endpointConf["Exchange"];

            if (queue == null && exchange == null)
            {
                throw new NullReferenceException($"Для {endpoint} не указан Queue или Exchange");
            }

            var factory = new ConnectionFactory
            {
                HostName = hostName,
                VirtualHost = virtualHost,
                UserName = userName,
                Password = password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            if (!string.IsNullOrWhiteSpace(queue))
            {
                channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            }

            var body = Encoding.UTF8.GetBytes(message);

            var properties = DictionaryToProperties(channel, param ?? new Dictionary<string, string>());

            channel.BasicPublish(exchange: exchange ?? "", routingKey: "", basicProperties: properties, body: body);

            return Task.CompletedTask;
        }

        private static IBasicProperties DictionaryToProperties(IModel channel, Dictionary<string, string> param)
        {
            // TODO: Рассмотреть замену на рефлексию.

            var properties = channel.CreateBasicProperties();

            properties.AppId = param.GetValueOrDefault("AppId");
            properties.ClusterId = param.GetValueOrDefault("ClusterId");
            properties.ContentEncoding = param.GetValueOrDefault("ContentEncoding");
            properties.ContentType = param.GetValueOrDefault("ContentType");
            properties.CorrelationId = param.GetValueOrDefault("CorrelationId");
            properties.DeliveryMode = byte.Parse(param.GetValueOrDefault("DeliveryMode") ?? "0");
            properties.Expiration = param.GetValueOrDefault("Expiration");
            properties.MessageId = param.GetValueOrDefault("MessageId");
            properties.Persistent = bool.Parse(param.GetValueOrDefault("Persistent") ?? "false");
            properties.Priority = byte.Parse(param.GetValueOrDefault("Priority") ?? "0");
            properties.ReplyTo = param.GetValueOrDefault("ReplyTo");
            properties.Type = param.GetValueOrDefault("Type");
            properties.UserId = param.GetValueOrDefault("UserId");

            return properties;
        }
    }
}