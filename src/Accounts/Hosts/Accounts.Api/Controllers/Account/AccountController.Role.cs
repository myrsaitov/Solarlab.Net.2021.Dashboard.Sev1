using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает роль текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("getcurrentuserroles")]
        public async Task<IActionResult> GetCurrentUserRoles(
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetCurrentUserRoles(
                cancellationToken));
        }

        /// <summary>
        /// Возвращает роль пользователя по Id
        /// </summary>
        /// <param name="request">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("getuserroles")]
        public async Task<IActionResult> GetUserRoles(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserIdDto request,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetUserRolesById(
                request.UserId,
                cancellationToken));
        }

        /// <summary>
        /// Добавляет указанного пользователя в указанную роль
        /// </summary>
        /// <param name="request">Id пользователя и роль</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost("role-add")]
        public async Task<IActionResult> AddToRole(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserRoleRequest request,
            CancellationToken cancellationToken)
        {
            await _identityService.AddToRole(
                request.UserId,
                request.Role,
                cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Убирает указанного пользователя из указанной роли
        /// </summary>
        /// <param name="request">Id пользователя и роль</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost("role-remove")]
        public async Task<IActionResult> RemoveFromRole(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserRoleRequest request,
            CancellationToken cancellationToken)
        {
            await _identityService.RemoveFromRole(
                request.UserId,
                request.Role,
                cancellationToken);

            return Ok();
        }
    }
}