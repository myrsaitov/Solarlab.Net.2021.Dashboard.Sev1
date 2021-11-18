using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sev1.Accounts.Domain.Base.Exceptions;
using Sev1.Accounts.Domain.Base.Exceptions.Base;

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

        public ApplicationExceptionHandler(
            RequestDelegate next,
            IOptions<ApplicationExceptionOptions> options,
            ILogger<ApplicationExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
            _options = options.Value;
        }

        /// <summary>
        /// Вызывается при исключении
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            // Передает управление в цепочке middleware следующему блоку
            try
            {
                await _next(context);
            }

            // Если случилось доменное исключение
            catch (DomainException domainException)
            {
                // Запись в журнал в категорию исключений
                _logger.LogError(
                    domainException,
                    "Прозошло доменное исключение.");

                // Назначает код исключения в зависимости от типа исключения
                context.Response.StatusCode = (int)ObtainStatusCode(domainException);

                // Замыкает middleware
                // и отправляет ответ с кодом исключения и собщением
                await context
                    .Response
                    .WriteAsJsonAsync(
                        new
                        {
                            TraceId = context.TraceIdentifier,
                            Error = domainException.Message,
                        },
                        context.RequestAborted);
            }

            // Если случилось любое другое исключение
            catch (Exception e)
            {
                // Запись в журнал в категорию исключений
                _logger.LogError(
                    e,
                    "Произошло общее исключение.");

                // Назначает код исключения по умолчанию
                context.Response.StatusCode = _options.DefaultErrorStatusCode;

                // Замыкает middleware
                // и отправляет ответ с кодом исключения и собщением
                await context
                    .Response
                    .WriteAsJsonAsync(
                        new
                        {
                            TraceId = context.TraceIdentifier,
                            Error = "Произошла ошибка"
                        },
                        context.RequestAborted);
            }
        }

        /// <summary>
        /// Возвращает код ошибки, в зависимости от вида исключения
        /// </summary>
        /// <param name="domainException">Доменное исключение</param>
        /// <returns></returns>
        private static HttpStatusCode ObtainStatusCode(
            DomainException domainException)
        {
            // В зависимости от типа исключения
            // возвращаем код ошибки
            return domainException switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ConflictException => HttpStatusCode.Conflict,
                NoRightsException => HttpStatusCode.Forbidden,
                BadRequestException => HttpStatusCode.BadRequest,
                _ => throw new ArgumentOutOfRangeException(nameof(domainException), domainException, null)
            };
        }
    }

    /// <summary>
    /// Класс для конфигурирования
    /// В данном случае конфигурируется код ошибки по умолчанию
    /// </summary>
    public class ApplicationExceptionOptions
    {
        public int DefaultErrorStatusCode { get; set; } = StatusCodes.Status500InternalServerError;
    }
}