using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sev1.Accounts.Contracts.Exceptions.Domain;
using Sev1.Accounts.Contracts.Exceptions.Domain.Base;

namespace Sev1.Accounts.Api.Controllers
{
    /// <summary>
    /// Класс обработчика исключений
    /// </summary>
    public class ApplicationExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApplicationExceptionHandler> _logger;
        private readonly ApplicationExceptionOptions _options;

        public ApplicationExceptionHandler(RequestDelegate next,
            IOptions<ApplicationExceptionOptions> options, ILogger<ApplicationExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
            _options = options.Value;
        }

        /// <summary>
        /// Вызывается при исключении
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException domainException)
            {
                _logger.LogError(domainException, "Прозошло доменное исключение.");

                context.Response.StatusCode = (int)ObtainStatusCode(domainException);
                await context.Response.WriteAsJsonAsync(new
                {
                    TraceId = context.TraceIdentifier,
                    Error = domainException.Message,
                }, context.RequestAborted);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошло общее исключение.");

                context.Response.StatusCode = _options.DefaultErrorStatusCode;
                await context.Response.WriteAsJsonAsync(new
                {
                    TraceId = context.TraceIdentifier,
                    Error = "Произошла ошибка"
                }, context.RequestAborted);
            }
        }

        /// <summary>
        /// Возвращает код ошибки, в зависимости от вида исключения
        /// </summary>
        /// <param name="domainException">Доменное исключение</param>
        /// <returns></returns>
        private static HttpStatusCode ObtainStatusCode(DomainException domainException)
        {
            return domainException switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ConflictException => HttpStatusCode.Conflict,
                NoRightsException => HttpStatusCode.Forbidden,
                _ => throw new ArgumentOutOfRangeException(nameof(domainException), domainException, null)
            };
        }
    }

    /// <summary>
    /// Код ошибки по умолчанию
    /// </summary>
    public class ApplicationExceptionOptions
    {
        public int DefaultErrorStatusCode { get; set; } = StatusCodes.Status500InternalServerError;
    }
}