using Sev1.Advertisements.Application.Services.Advertisement.Implementations;
using Sev1.Advertisements.Application.Services.Advertisement.Interfaces;
using Sev1.Advertisements.Application.Services.Tag.Implementations;
using Sev1.Advertisements.Application.Services.Tag.Interfaces;
using Sev1.Advertisements.Application.Services.Category.Implementations;
using Sev1.Advertisements.Application.Services.Category.Interfaces;
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