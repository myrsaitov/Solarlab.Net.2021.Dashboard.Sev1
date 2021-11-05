using EventBusRabbitMQ.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Services
{
    public class RabbitMQSubscriber : IRabbitMQSubscriber
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IModel _model;
        private readonly string _exchange;
        private readonly string _queue;
        private bool _disposed = false;

        public RabbitMQSubscriber(IRabbitMQConnection connection, string queue, string routingKey)
        {
            _connection = connection;
            _model = _connection.GetConnection().CreateModel();
            _queue = queue;
            _exchange = _connection.GetExhangeName();
            _model.ExchangeDeclare(exchange: _exchange, type: ExchangeType.Topic, durable: true, autoDelete: false, arguments: null);
            _model.QueueDeclare(queue: _queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            _model.QueueBind(queue: _queue, exchange: _exchange, routingKey: routingKey, arguments: null);
        }


        /// <inheritdoc/>
        public void Subscribe(Func<string, IDictionary<string, object>, Task<bool>> callback)
        {
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                bool success = await callback.Invoke(message, ea.BasicProperties.Headers);
                if (success)
                {
                    _model.BasicAck(ea.DeliveryTag, true);
                }
            };

            _model.BasicConsume(queue: _queue, autoAck: false, consumer: consumer);
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
                _model?.Close();

            _disposed = true;
        }
    }
}
