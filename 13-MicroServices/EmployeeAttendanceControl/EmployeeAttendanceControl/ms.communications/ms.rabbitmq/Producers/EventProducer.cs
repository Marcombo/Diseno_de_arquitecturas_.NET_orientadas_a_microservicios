using System.Text;
using ms.rabbitmq.Events;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;

namespace ms.rabbitmq.Producers
{
    public class EventProducer : IProducer
    {
        private readonly IConfiguration _configuration;
        public EventProducer(IConfiguration configuration) => _configuration = configuration;

        public void Produce(RabbitMqEvent rabbitmqEvent) {
            var factory = new ConnectionFactory() {
                HostName = _configuration.GetValue<string>("Communication:EventBus:HostName")
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queue = rabbitmqEvent.GetType().Name;

                channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, null);

                var body = Encoding.UTF8.GetBytes(rabbitmqEvent.Serialize());

                channel.BasicPublish("", queue, null, body);
            }
        }
    }
}
