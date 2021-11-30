using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает идентификатор текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("current-user-id")]
        public IActionResult GetCurrentUserId(
            CancellationToken cancellationToken)
        {
            // Т.к. GetCurrentUserId синхронный, то и контроллер делаем синхронным.
            // Каждый такой случай нужно рассматривать индивидуально.
            return Ok(new CurrentUserIdResponse()
            {
                UserId = _identityService.GetCurrentUserId(cancellationToken)
            });
        }

        /// <summary>
        /// Возвращает текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser(
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetCurrentUser(cancellationToken));
        }

        /// <summary>
        /// Возвращает пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserById(
            [FromRoute]
            string userId,
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.Get(
                userId,
                cancellationToken));
        }

        /// <summary>
        /// Возвращает пользователей с пагинацией
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] // Get values from the query string, e.g.: ?PageSize=10&Page=0
            UserGetPagedRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetPaged(
                request,
                cancellationToken));
        }
    }
}