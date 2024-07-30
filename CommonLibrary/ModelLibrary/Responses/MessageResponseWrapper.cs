using System;
namespace ModelLibrary.Responses
{
    public class MessageResponseWrapper<T>
    {
        public required T Content { get; set; }
    }
}