using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;

/// <summary>
/// Механизм внедрения зависимостей в задачи, вызываемые по расписанию технологией "Quartz"
/// </summary>
public class SingletonJobFactory : IJobFactory
{
    private readonly IServiceProvider _serviceProvider;
    public SingletonJobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Вызывается при срабатывании триггера, внедряет зависимости при вызове "Execute"
    /// </summary>
    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
    }

    public void ReturnJob(IJob job) { }
}