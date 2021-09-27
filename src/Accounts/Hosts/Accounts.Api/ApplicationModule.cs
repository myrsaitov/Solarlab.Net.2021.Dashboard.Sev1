using Sev1.Accounts.Application.Implementations.Advertisement;
using Sev1.Accounts.Application.Implementations.Tag;
using Sev1.Accounts.Application.Implementations.Category;
using Sev1.Accounts.Application.Interfaces.Advertisement;
using Sev1.Accounts.Application.Interfaces.Category;
using Sev1.Accounts.Application.Interfaces.Tag;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Sev1.Accounts.Api
{
    public static class ApplicationModule
    {
        // Через IServiceCollection сервисы и добавляются в проект.
        public static IServiceCollection AddApplicationModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            // AddScoped:
            //
            // This method creates a Scoped service.
            // A new instance of a Scoped service is created
            // once per request within the scope.
            // For example, in a web application it creates 1 instance
            // per each http request but uses the same instance
            // in the other calls within that same web request.
            services.AddScoped<ICategoryService, CategoryServiceV1>();
            services.AddScoped<IAdvertisementService, AdvertisementServiceV1>();
            services.AddScoped<ITagService, TagServiceV1>();

            return services;
        }
    }
}