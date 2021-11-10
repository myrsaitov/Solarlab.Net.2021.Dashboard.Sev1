using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User;

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
            var currentUserId = await Task.FromResult(_identityService.GetCurrentUserId(cancellationToken));
            
            return Ok(currentUserId);
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
            var currentUserId = _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);

            return Ok(new UserResponseDto()
            {
                UserName = domainUser.UserName,
                FirstName = domainUser.FirstName,
                LastName = domainUser.LastName,
                MiddleName = domainUser.MiddleName
            });
        }

        /// <summary>
        /// Возвращает пользователя по его идентификатору
        /// </summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<IActionResult> GetUserById(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            string UserId,
            CancellationToken cancellationToken)
        {
            var domainUser = await _userService.Get(
                UserId,
                cancellationToken);

            return Ok(domainUser);
        }
    }
}