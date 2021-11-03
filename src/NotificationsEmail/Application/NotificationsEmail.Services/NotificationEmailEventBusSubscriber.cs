using EventBusRabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NotificationsEmail.Contracts;
using NotificationsEmail.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.Services
{
    public class NotificationEmailEventBusSubscriber : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IRabbitMQSubscriber _subscriber;
        public NotificationEmailEventBusSubscriber(IRabbitMQSubscriber subscriber, 
            IServiceScopeFactory scopeFactory)
        {
            _subscriber = subscriber;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        public bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dto = JsonConvert.DeserializeObject<LetterDto>(message);
                var _notificationEmailService = scope.ServiceProvider.GetRequiredService<INotificationEmailService>();
                _notificationEmailService.SendNewEmailAsync(dto);
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
