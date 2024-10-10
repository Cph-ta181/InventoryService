using RabbitMQ.Client;
using Microsoft.Extensions.Options;
using Google.Protobuf;

namespace InventorySerivce.Services.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQProducer(IOptions<RabbitMQSettings> options)
        {
            var factory = new ConnectionFactory
            {
                HostName = options.Value.HostName,
                UserName = options.Value.UserName,
                Password = options.Value.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void SendMessage<T>(T message, string queueName) where T : IMessage<T>
        {
            var channel = _connection.CreateModel();

            // Ensure the queue exists
            channel.QueueDeclare(queue: 
                queueName,
                durable: false, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);

            // Serialize the Protobuf object to byte array
            byte[] body = message.ToByteArray();

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            // Send the serialized message to RabbitMQ
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: properties, body: body);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
