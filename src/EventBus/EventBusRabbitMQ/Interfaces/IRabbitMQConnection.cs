using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQConnection : IDisposable
    {
        IConnection GetConnection();
        string GetExhangeName();
    }
}