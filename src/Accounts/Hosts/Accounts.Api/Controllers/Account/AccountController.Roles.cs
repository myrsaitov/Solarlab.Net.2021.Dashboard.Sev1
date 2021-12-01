using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User;
using Sev1.Accounts.Contracts.Contracts.User.Requests;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Возвращает роли авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-current-user-roles")]
        public async Task<IActionResult> GetCurrentUserRoles(
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetCurrentUserRoles(
                cancellationToken));
        }

        /// <summary>
        /// Возвращает роли пользователя по идентификатору
        /// </summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-user-roles")]
        public async Task<IActionResult> GetUserRoles(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            string UserId,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetUserRolesById(
                UserId,
                cancellationToken));
        }

        /// <summary>
        /// Добавляет указанного пользователя в указанную роль
        /// </summary>
        /// <param name="request">Идентификатор пользователя и роль</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPut("role-add")]
        public async Task<IActionResult> AddToRole(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserRoleChangeRequest request,
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
        /// <param name="request">Идентификатор пользователя и роль</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPut("role-remove")]
        public async Task<IActionResult> RemoveFromRole(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserRoleChangeRequest request,
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