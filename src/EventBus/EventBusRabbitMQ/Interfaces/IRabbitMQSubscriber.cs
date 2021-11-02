using System;
using System.Collections.Generic;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQSubscriber
    {
        void Subscribe(Func<string, IDictionary<string, object>, bool> callback);
    }
}