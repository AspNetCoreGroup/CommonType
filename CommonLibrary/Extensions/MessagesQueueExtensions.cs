using CommonLibrary.Interfaces.Listeners;
using CommonLibrary.Interfaces.Senders;
using ModelLibrary.Events;
using System.Text.Json;

namespace CommonLibrary.Extensions
{
    public static class MessagesQueueExtensions
    {
        public delegate void OnMessageRecievedSimpleHandler(string queueName, string message, Dictionary<string, string> param);
        public delegate void OnMessageRecievedQueueHandler(string message, Dictionary<string, string> param);
        public delegate void OnMessageRecievedArgsHandler(MessageRecievedEventArgs args);

        public static Task SendMessageAsync<T>(this IMessageSender sender, string endpoint, T message)
        {
            var type = typeof(T);
            var contentType = GetTypeShortName(type);

            var param = new Dictionary<string, string>()
            {
                { "ContentType", contentType }
            };

            var messageText = JsonSerializer.Serialize(message);

            return sender.SendMessageAsync(endpoint, messageText, param);
        }

        public static void AddHandler(this IMessageListener listener, OnMessageRecievedSimpleHandler onMessage)
        {
            listener.AddHandler(new StringMessageHandler()
            {
                OnMessage = onMessage
            });
        }

        public static void AddHandler(this IMessageListener listener, OnMessageRecievedQueueHandler onMessage)
        {
            listener.AddHandler(new QueueMessageHandler()
            {
                OnMessage = onMessage
            });
        }

        public static void AddHandler(this IMessageListener listener, OnMessageRecievedArgsHandler onMessage)
        {
            listener.AddHandler(new ArgsMessageHandler()
            {
                OnMessage = onMessage
            });
        }

        private static string GetTypeShortName(Type type)
        {
            if (type.IsGenericType)
            {
                var typeName = type.Name.Split("`")[0];
                var genericTypes = type.GenericTypeArguments.Select(GetTypeShortName);

                return typeName + "<" + string.Join(", ", genericTypes) + ">";
            }
            else
            {
                return type.Name;
            }
        }

        #region

        private class StringMessageHandler : IMessageHandler
        {
            public required OnMessageRecievedSimpleHandler OnMessage { get; set; }

            public void OnMessageRecieved(MessageRecievedEventArgs args)
            {
                OnMessage.Invoke(args.QueueName, args.Message, args.Param);
            }
        }

        private class QueueMessageHandler : IMessageHandler
        {
            public required OnMessageRecievedQueueHandler OnMessage { get; set; }

            public void OnMessageRecieved(MessageRecievedEventArgs args)
            {
                OnMessage.Invoke(args.Message, args.Param);
            }
        }

        private class ArgsMessageHandler : IMessageHandler
        {
            public required OnMessageRecievedArgsHandler OnMessage { get; set; }

            public void OnMessageRecieved(MessageRecievedEventArgs args)
            {
                OnMessage.Invoke(args);
            }
        }

        #endregion
    }
}