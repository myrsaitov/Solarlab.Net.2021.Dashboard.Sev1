﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}