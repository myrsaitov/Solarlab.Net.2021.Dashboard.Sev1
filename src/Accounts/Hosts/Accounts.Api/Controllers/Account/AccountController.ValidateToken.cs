using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Проверка токена.
        /// Возвращает идентификатор и роли 
        /// авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("validate-token")]
        public async Task<IActionResult> ValidateToken(
            CancellationToken cancellationToken)
        {
            return Ok(
                await _identityService
                    .ValidateToken(cancellationToken));
        }
    }
}