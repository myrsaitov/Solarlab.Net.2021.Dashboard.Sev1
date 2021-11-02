using RabbitMQ.Client;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQConnection
    {
        IConnection GetConnection();
    }
}