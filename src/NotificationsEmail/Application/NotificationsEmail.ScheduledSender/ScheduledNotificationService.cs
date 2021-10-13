using Microsoft.Extensions.DependencyInjection;
using NotificationsEmail.Domain.Entities;
using NotificationsEmail.Services.Interfaces;
using Quartz;
using System.Threading.Tasks;

namespace NotificationsEmail.ScheduledSender
{
    public class ScheduledNotificationService : IJob
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ScheduledNotificationService(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Загрузка неотправленных писем из бд для повторной попытки отправки.
        /// Из БД загружаются все письма со статусом New && Trying за последние сутки
        /// </summary>
        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                var _notificationEmailService = scope.ServiceProvider.GetRequiredService<INotificationEmailService>();

                var letters = await _repository.GetNotSendedLettersForLastDay();
                foreach (Letter letter in letters)
                {
                    await _notificationEmailService.SendExistedEmailAndSaveResult(letter);
                }
            }
        }
    }
}
