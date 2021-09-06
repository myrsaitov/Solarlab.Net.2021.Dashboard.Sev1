using System;
using Sev1.Advertisements.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.DataAccess.Interfaces;

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
    public static class DataAccessModule
    {
        public sealed class ModuleConfiguration
        {
            public IServiceCollection Services { get; init; }
        }

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


        public static void InSqlServer(this ModuleConfiguration moduleConfiguration, string connectionString)
        {
            moduleConfiguration.Services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString, builder =>
                    builder.MigrationsAssembly(
                        typeof(DataAccessModule).Assembly.FullName)
                        );
            });

            moduleConfiguration.Services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            moduleConfiguration.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            moduleConfiguration.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            moduleConfiguration.Services.AddScoped<ITagRepository, TagRepository>();

        }
    }
}