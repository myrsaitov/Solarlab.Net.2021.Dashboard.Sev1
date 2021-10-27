using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Identity;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает Id и роль текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("getautorizedstatus")]
        public async Task<IActionResult> GetAutorizedStatus(
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetAutorizedStatus(
                cancellationToken));
        }
    }
}