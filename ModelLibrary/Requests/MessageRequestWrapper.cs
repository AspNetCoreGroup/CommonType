using System;
namespace ModelLibrary.Requests
{
    public class MessageRequestWrapper<T>
    {
        public required T Content { get; set; }
        public string? CallbackQueue { get; set; }
    }
}