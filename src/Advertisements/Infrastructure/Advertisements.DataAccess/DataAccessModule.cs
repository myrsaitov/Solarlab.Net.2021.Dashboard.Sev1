﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Advertisements.AppServices.Services.Advertisement.Repositories;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;
using Sev1.Advertisements.DataAccess.Repositories;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.Domain.Base.Repositories;
using Sev1.Advertisements.AppServices.Services.Region.Repositories;

// Nugets:
// Microsoft.EntityFrameworkCore
// Microsoft.EntityFrameworkCore.Design
// Microsoft.EntityFrameworkCore.SqlServer
// Microsoft.EntityFrameworkCore.Tools
// Microsoft.Extensions.DependencyInjection.Abstractions
// Mapster
// Mapster.DependencyInjection

namespace Sev1.Advertisements.DataAccess
{
    /// <summary>
    /// Конфигурирование Middleware слоя DataAccess
    /// </summary>
    public static class DataAccessModule
    {
        /// <summary>
        /// Настройки
        /// </summary>
        public sealed class ModuleConfiguration
        {
            public IServiceCollection Services { get; init; }
        }

        /// <summary>
        /// Вызывается из "ConfigureServices"
        /// </summary>
        /// <param name="services">Список сервисов</param>
        /// <param name="action">Настройки</param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessModule(
            this IServiceCollection services,
            Action<ModuleConfiguration> action
        )
        {
            var moduleConfiguration = new ModuleConfiguration
            {
                Services = services
            };
            action(moduleConfiguration);
            return services;
        }

        /// <summary>
        /// Вызывается из "ConfigureServices"
        /// </summary>
        /// <param name="moduleConfiguration">Настройки</param>
        /// <param name="connectionString">Строка подключения БД</param>
        public static void InSqlServer(this ModuleConfiguration moduleConfiguration, string connectionString)
        {
            moduleConfiguration.Services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString, builder =>
                    builder.MigrationsAssembly(
                        typeof(DataAccessModule).Assembly.FullName)
                        );
            });

            // AddScoped:
            //
            // This method creates a Scoped service.
            // A new instance of a Scoped service is created
            // once per request within the scope.
            // For example, in a web application it creates 1 instance
            // per each http request but uses the same instance
            // in the other calls within that same web request.
            moduleConfiguration.Services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            moduleConfiguration.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            moduleConfiguration.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            moduleConfiguration.Services.AddScoped<ITagRepository, TagRepository>();
            moduleConfiguration.Services.AddScoped<IRegionRepository, RegionRepository>();

        }
    }
}