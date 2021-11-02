using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает Id и роль текущего 
        /// авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("validate-token")]
        public async Task<IActionResult> ValidateToken(
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.ValidateToken(
                cancellationToken));
        }
    }
}