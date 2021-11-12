using Microsoft.AspNetCore.Http;
using Sev1.Accounts.Contracts.ApiClients.User;
using System.Linq;
using System.Threading.Tasks;

namespace Sev1.Accounts.Contracts.Authorization
{
    public sealed class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserApiClient _userApiClient;

        public JwtMiddleware(
            RequestDelegate next,
            IUserApiClient userApiClient)
        {
            _next = next;
            _userApiClient = userApiClient;
        }

        public async Task Invoke(
            HttpContext context)
        {
            // Возвращаем JWT-токен из Headers
            var token = context
                .Request
                .Headers["Authorization"]
                .FirstOrDefault();
            
            if (string.IsNullOrWhiteSpace(token))
            {
                // Если токена нет (работаем анонимно)
                context.Items["Anonimous"] = "Anonimous";
            }
            else
            {
                // Валидация JWT-токена
                var res = await _userApiClient.ValidateToken(token);

                // Если валидация JWT-токена удачная,
                if (res != null)
                {
                    // то добавляем в каждую роль информацию о пользователе
                    foreach (var role in res.Roles)
                    {
                        context.Items[role] = res.UserId;
                    }
                }
            }
            // Передаем управление следующему middleware
            await _next(context);
        }
    }
}