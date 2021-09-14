using Sev1.Advertisements.Application.Implementations.Advertisement;
using Sev1.Advertisements.Application.Implementations.Tag;
using Sev1.Advertisements.Application.Implementations.Category;
using Sev1.Advertisements.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Sev1.Advertisements.Api
{
    public static class ApplicationModule
    {
        // Через IServiceCollection сервисы и добавляются в проект.
        public static IServiceCollection AddApplicationModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryServiceV1>();
            services.AddScoped<IAdvertisementService, AdvertisementServiceV1>();
            services.AddScoped<ITagService, TagServiceV1>();

            return services;
        }
    }
}