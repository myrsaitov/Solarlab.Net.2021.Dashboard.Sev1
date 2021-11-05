using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQSubscriber : IDisposable
    {
        /// <summary>
        /// Подписаться на очередь
        /// </summary>
        /// <param name="callback">Функция, вызываемая при получении сообщения</param>
        public void Subscribe(Func<string, IDictionary<string, object>, Task<bool>> callback);
    }
}