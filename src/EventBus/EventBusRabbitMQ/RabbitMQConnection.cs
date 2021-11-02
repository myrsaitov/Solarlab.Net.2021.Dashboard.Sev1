using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IDisposable, IRabbitMQConnection
    {
        private readonly IConnection _connection;

        public RabbitMQConnection(ConnectionFactory factory)
        {
            _connection = factory.CreateConnection();
        }
        public IConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
