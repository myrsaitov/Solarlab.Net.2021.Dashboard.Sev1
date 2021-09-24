using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Comments.Domain.Exceptions;

namespace Comments.API.Filters
{
    public class CommentsExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<CommentsExceptionFilter> _logger;

        public CommentsExceptionFilter(ILogger<CommentsExceptionFilter> logger)
        {
            _logger = logger;
        }
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
            }
            return Task.FromResult<object>(context);
        }
    }
}
