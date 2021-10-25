using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает Id текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("currentuserid")]
        public async Task<IActionResult> GetCurrentUserId(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);
            
            return Ok(domainUser.Id);
        }

        /// <summary>
        /// Возвращает текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("currentuser")]
        public async Task<IActionResult> GetCurrentUser(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);

            return Ok(domainUser);
        }

        /// <summary>
        /// Возвращает пользователя по его Id
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("user")]
        public async Task<IActionResult> GetUserById(
            string userId,
            CancellationToken cancellationToken)
        {
            var domainUser = await _userService.Get(userId, cancellationToken);

            return Ok(domainUser);
        }
    }
}