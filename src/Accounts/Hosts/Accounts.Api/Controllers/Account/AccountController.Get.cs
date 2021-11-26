using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Accounts.Domain;

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
        [HttpPost("current-user-id")]
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
        [HttpPost("current-user")]
        public async Task<IActionResult> GetCurrentUser(
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetCurrentUser(cancellationToken));
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

        /// <summary>
        /// Возвращает пользователя по его идентификатору
        /// </summary>
        /// <param name="UserList">Идентификаторы пользователей</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("users")]
        public async Task<IActionResult> GetUsersByListId(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            List<string> UserList,
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersByListId(UserList, cancellationToken);

            return Ok(result);
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