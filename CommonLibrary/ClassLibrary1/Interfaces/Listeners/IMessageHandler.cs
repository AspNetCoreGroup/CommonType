﻿namespace CommonLibrary.Interfaces.Listeners
{
    public interface IMessageHandler
    {
        void OnMessageRecieved(string queueName, string message);
    }
}