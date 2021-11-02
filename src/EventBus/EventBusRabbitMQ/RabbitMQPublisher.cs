using EventBusRabbitMQ.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IModel _model;
        private readonly string _exchange;

        public RabbitMQPublisher(IRabbitMQConnection connection)
        {
            _connection = connection;
            _model = _connection.GetConnection().CreateModel();
            _exchange = _connection.GetExhangeName();
            _model.ExchangeDeclare(exchange: _exchange, type: ExchangeType.Topic, durable: true, autoDelete: false, arguments: null);
        }
        public void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes)
        {
            var body = Encoding.UTF8.GetBytes(message);
            var properties = _model.CreateBasicProperties();
            properties.DeliveryMode = 2; // Persistence-режим сообщения
            properties.Headers = messageAttributes;

            _model.BasicPublish(exchange: _exchange, routingKey: routingKey, basicProperties: properties, body: body);
        }
    }
}
