using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.ScheduledSender
{
    /// <summary>
    /// Сервис запуска задачи проверки пропущенных писем 
    /// </summary>
    public class NotificationScheduler : IHostedService
    {
        private readonly IJobFactory _jobFactory;
        private IScheduler _scheduler { get; set; }

        public NotificationScheduler(
            IJobFactory jobFactory)
        {
            _jobFactory = jobFactory;
        }

        /// <summary>
        /// Создание тригера
        /// </summary>
        /// <returns></returns>
        private ITrigger CreateTrigger()
        {
            var trigger = TriggerBuilder
                .Create()
                .WithIdentity("MyTrigger")          // идентификатор
                .StartNow()                         // запустить немедленно 
                .WithSimpleSchedule(x => x          //
                    .WithIntervalInMinutes(10)      // интервал - 10 мин
                    .RepeatForever())               // бесконечно повторять
                .Build();

            return trigger;
        }

        /// <summary>
        /// IHostedService функция
        /// Создание и запуск задачи с помощью "Quartz" 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            _scheduler.JobFactory = _jobFactory;

            var trigger = CreateTrigger();
            var job = JobBuilder.Create<ScheduledNotificationService>().Build();

            await _scheduler.ScheduleJob(job, trigger, cancellationToken);
            await _scheduler.Start(cancellationToken);
        }

        /// <summary>
        /// Остановка работы сервиса
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler?.Shutdown(cancellationToken);
        }
    }
}
