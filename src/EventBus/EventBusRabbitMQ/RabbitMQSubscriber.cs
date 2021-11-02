using EventBusRabbitMQ.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public class RabbitMQSubscriber : IRabbitMQSubscriber
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IModel _model;
        private readonly string _exchange;
        private readonly string _queue;

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
        public void Subscribe(Func<string, IDictionary<string, object>, bool> callback)
        {
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                bool success = callback.Invoke(message, ea.BasicProperties.Headers);
                if (success)
                {
                    _model.BasicAck(ea.DeliveryTag, true);
                }
            };

            _model.BasicConsume(queue: _queue, autoAck: false, consumer: consumer);
        }
    }
}
