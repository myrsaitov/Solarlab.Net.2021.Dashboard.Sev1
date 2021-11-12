using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sev1.UserFiles.Api.Controllers
{
    /// <summary>
    /// Класс для обработчика подключения исключений к цепочке Middleware
    /// </summary>
    public static class ApplicationExceptionExtensions
    {
        /// <summary>
        /// Вызывается в Configure
        /// </summary>
        /// <param name="app">Сущность ApplicationBuilder</param>
        public static void UseApplicationException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApplicationExceptionHandler>();
        }

        /// <summary>
        /// Вызывается в ConfigureServices
        /// </summary>
        /// <param name="services">Сущность ServiceCollection</param>
        /// <param name="setupAction">Делегат с конфигурацией</param>
        public static void AddApplicationException(
            this IServiceCollection services,
            Action<ApplicationExceptionOptions> setupAction = null)
        {
            services.Configure(setupAction);
        }
    }
}