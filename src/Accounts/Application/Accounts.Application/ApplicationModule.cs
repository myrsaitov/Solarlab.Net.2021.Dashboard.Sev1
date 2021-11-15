using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Implementations;

namespace Sev1.Accounts.AppServices
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
            services
                .AddScoped<IUserService, UserServiceV1>();

            return services;
        }
    }
}