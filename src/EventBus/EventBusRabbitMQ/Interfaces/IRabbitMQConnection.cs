using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQConnection : IDisposable
    {
        /// <summary>
        /// Получить IConnection 
        /// </summary>
        /// <returns></returns>
        IConnection GetConnection();

        /// <summary>
        /// Получить имя Exhange 
        /// </summary>
        /// <returns></returns>
        string GetExhangeName();
    }
}