using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sev1.Accounts.Api.Controllers
{
    public static class ApplicationExceptionExtensions
    {
        public static void UseApplicationException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApplicationExceptionHandler>();
        }

        public static void AddApplicationException(this IServiceCollection services,
            Action<ApplicationExceptionOptions> setupAction = null)
        {
            services.Configure(setupAction);
        }
    }
}