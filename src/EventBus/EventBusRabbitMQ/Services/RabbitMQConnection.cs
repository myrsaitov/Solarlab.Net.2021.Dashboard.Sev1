using EventBusRabbitMQ.Interfaces;
using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ.Services
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        const string EXCHANGE_NAME = "sev1_exchange";
        private readonly IConnection _connection;
        private bool _disposed = false;

        public RabbitMQConnection(ConnectionFactory factory)
        {
            _connection = factory.CreateConnection();
        }
        public IConnection GetConnection()
        {
            return _connection;
        }
        public string GetExhangeName()
        {
            return EXCHANGE_NAME;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _connection?.Close();

            _disposed = true;
        }
    }
}
