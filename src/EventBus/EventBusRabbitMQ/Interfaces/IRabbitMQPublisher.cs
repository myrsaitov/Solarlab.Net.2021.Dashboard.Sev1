using System;
using System.Collections.Generic;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQPublisher : IDisposable
    {
        void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes);
    }
}