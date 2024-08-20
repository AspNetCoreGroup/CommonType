using CommonLibrary.Interfaces.Listeners;
using Microsoft.Extensions.Configuration;
using ModelLibrary.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitLibrary.Listeners
{
    public sealed class RabbitListener : IMessageListener
    {
        #region Поля

        private IConfiguration Configuration { get; }

        private string Queue { get; }

        private IConnection? Connection { get; set; }

        private IModel? Channel { get; set; }

        private Queue<IMessageHandler> Handlers { get; }

        #endregion

        public RabbitListener(IConfiguration configuration, string queue)
        {
            Configuration = configuration;
            Queue = queue;

            Handlers = new Queue<IMessageHandler>();
        }

        public void AddHandler(IMessageHandler messageHandler)
        {
            Handlers.Enqueue(messageHandler);
        }

        public void Open()
        {
            var endpointConf = Configuration.GetSection($"Senders/RabbitMQ/Endpoints/{Queue}");

            var hostName = endpointConf["HostName"] ?? throw new NullReferenceException($"Для {Queue} не указан HostName");
            var virtualHost = endpointConf["VirtualHost"] ?? throw new NullReferenceException($"Для {Queue} не указан VirtualHost");
            var userName = endpointConf["UserName"] ?? throw new NullReferenceException($"Для {Queue} не указан UserName");
            var password = endpointConf["Password"] ?? throw new NullReferenceException($"Для {Queue} не указан Password");
            var queue = endpointConf["Queue"] ?? throw new NullReferenceException($"Для {Queue} не указан Queue");

            var factory = new ConnectionFactory
            {
                HostName = hostName,
                VirtualHost = virtualHost,
                UserName = userName,
                Password = password
            };

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();

            Channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var param = PropertiesToDictionary(ea.BasicProperties);

                var args = new MessageRecievedEventArgs()
                {
                    QueueName = queue,
                    Message = content,
                    Param = param,
                    Failed = false,
                    Hadled = false,
                    Rejected = false,
                    Resended = false,
                };

                foreach (var handler in Handlers)
                {
                    if (args.Resended)
                    {
                        Channel.BasicReject(ea.DeliveryTag, true);
                        return;
                    }

                    if (args.Rejected)
                    {
                        Channel.BasicReject(ea.DeliveryTag, false);
                        return;
                    }

                    if (args.Hadled)
                    {
                        Channel.BasicAck(ea.DeliveryTag, false);
                        return;
                    }

                    handler.OnMessageRecieved(args);
                }

                Channel.BasicAck(ea.DeliveryTag, false);
            };

            Channel.BasicConsume(queue, false, consumer);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Channel?.Close();
            Connection?.Close();
        }

        private static Dictionary<string, string> PropertiesToDictionary(IBasicProperties properties)
        {
            // TODO: Рассмотреть замену на рефлексию.

            return new Dictionary<string, string>()
            {
                { "AppId", properties.AppId },
                { "ClusterId", properties.ClusterId },
                { "ContentEncoding", properties.ContentEncoding },
                { "ContentType", properties.ContentType },
                { "CorrelationId", properties.CorrelationId },
                { "DeliveryMode", properties.DeliveryMode.ToString() },
                { "Expiration", properties.Expiration },
                { "MessageId", properties.MessageId },
                { "Persistent", properties.Persistent.ToString() },
                { "Priority", properties.Priority.ToString() },
                { "ReplyTo", properties.ReplyTo },
                { "Type", properties.Type },
                { "UserId", properties.UserId }
            };
        }
    }
}