﻿using CommonLibrary.Interfaces.Listeners;
using CommonLibrary.Interfaces.Senders;
using System.Text.Json;

namespace CommonLibrary.Extensions
{
    public static class MessagesQueueExtensions
    {
        public delegate void OnMessageRecievedHandler(string queueName, string message, Dictionary<string, string> param);

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

        public static void AddHandler(this IMessageListener listener, OnMessageRecievedHandler onMessage)
        {
            listener.AddHandler(new StringMessageHandler()
            {
                OnMessage = onMessage
            });
        }

        private class StringMessageHandler : IMessageHandler
        {
            public required OnMessageRecievedHandler OnMessage { get; set; }

            public void OnMessageRecieved(string queueName, string message, Dictionary<string, string> param)
            {
                OnMessage.Invoke(queueName, message, param);
            }
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
    }
}

