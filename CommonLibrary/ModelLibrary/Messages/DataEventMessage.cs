using ModelLibrary.Model.Enums;

namespace ModelLibrary.Messages
{
    public class DataEventMessage<T> where T : class
    {
        public DataEventOperationType Operation { get; set; }
        public T? Data { get; set; }
    }
}