using Google.Protobuf;

namespace InventorySerivce.Services.RabbitMQ
{
    public interface IRabbitMQProducer : IDisposable
    {
        public void SendMessage<T>(T message, string queueName) where T : IMessage<T>;
    }
}
