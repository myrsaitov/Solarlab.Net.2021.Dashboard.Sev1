using EventBusRabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NotificationsEmail.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.Services
{
    /// <summary>
    /// Сервис прослушивания очереди
    /// </summary>
    public class NotificationEmailRabbitMQConsumer : IHostedService
    {
        private readonly IRabbitMQSubscriber _subscriber;
        private readonly string _serviceUrl;
        public NotificationEmailRabbitMQConsumer(IRabbitMQSubscriber subscriber, IConfiguration configuration)
        {
            _subscriber = subscriber;
            _serviceUrl = configuration["NotificationEmailApiUrl"];
        }
        /// <summary>
        /// Подписываемся на очередь, 
        /// При получении сообщение - вызов ProcessMessageAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(ProcessMessageAsync);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Обработка сообщения - перенаправление на NotificationEmail.api
        /// </summary>
        /// <param name="message"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<bool> ProcessMessageAsync(string message, IDictionary<string, object> headers)
        {
            // TODO: обработать исключение
            try
            {
                using (var client = new HttpClient())
                {
                    var values = JsonSerializer.Deserialize<Dictionary<string, string>>(message);
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(_serviceUrl, content);
                }
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Остановка приема сообщений 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscriber.Dispose();
            return Task.CompletedTask;
        }
    }
}
