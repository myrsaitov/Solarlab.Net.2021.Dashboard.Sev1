using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Comments.Domain.Exceptions;

namespace Comments.API.Filters
{
    /// <summary>
    /// Фильтр ошибок для контроллера, атрибут
    /// Ловт NotFounException и другие, возврощает Response со статус кодом 404/500
    /// </summary>
    public class CommentsExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<CommentsExceptionFilter> _logger;
        
        public CommentsExceptionFilter(ILogger<CommentsExceptionFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Ловит ошибку "NotFoundException", возвращает 404 код и сообщение и ID сущности
        /// Ловит другие ошибки, возвращает код 500
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            if (context != null)
            {
                if (context.Exception.GetType() == typeof(NotFoundException))
                {
                    context.Result = new ContentResult
                    {
                        Content = $"Комментарий не был найден, {context.Exception.Message}\n "
                    };
                context.ExceptionHandled = true;
                    context.HttpContext.Response.StatusCode = 404;
                } else
                {
                    context.Result = new ContentResult
                    {
                        Content = $"Исключение {context.Exception.GetType()}, msg={context.Exception.Message}\n "
                    };
                    context.ExceptionHandled = true;
                    context.HttpContext.Response.StatusCode = 500;
                }

                _logger.LogError(context.Exception.GetType().FullName + " : " + context.Exception.Message + " : " + context.Exception.StackTrace,
                    context.HttpContext.Request.Path + context.HttpContext.Request.Method);
            }
            return Task.FromResult<object>(context);
        }
    }
}
