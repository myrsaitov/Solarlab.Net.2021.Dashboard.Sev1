using System;
using System.Collections.Generic;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQPublisher : IDisposable
    {
        /// <summary>
        /// Отправить сообщение на exchange
        /// exchange.Type = Topic
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="routingKey">routing key</param>
        /// <param name="messageAttributes">Аттрибуты</param>
        void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes);
    }
}