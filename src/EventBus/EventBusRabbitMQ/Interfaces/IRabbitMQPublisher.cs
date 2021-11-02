using System.Collections.Generic;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQPublisher
    {
        void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes);
    }
}