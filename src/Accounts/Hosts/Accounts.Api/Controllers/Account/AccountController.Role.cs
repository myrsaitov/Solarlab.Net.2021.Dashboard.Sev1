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
        /// Проверка на роль админа
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("isadmin")]
        public async Task<IActionResult> IsAdmin(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var isAdmin = await _identityService.IsInRole(currentUserId, RoleConstants.AdminRole, cancellationToken);

            return Ok(isAdmin.ToString().ToLower());
        }

        /// <summary>
        /// Проверка на роль модератора
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("ismoderator")]
        public async Task<IActionResult> IsModerator(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var isModerator = await _identityService.IsInRole(currentUserId, RoleConstants.ModeratorRole, cancellationToken);

            return Ok(isModerator.ToString().ToLower());
        }

        /// <summary>
        /// Возвращает роль текущего авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("getcurrentuserrole")]
        public async Task<IActionResult> GetCurrentUserRole(
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetCurrentUserRole(
                cancellationToken));
        }

        /// <summary>
        /// Возвращает роль пользователя по Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpPost("getuserrole")]
        public async Task<IActionResult> GetUserRole(
            string userId,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.GetUserRoleById(
                userId,
                cancellationToken));
        }

        /// <summary>
        /// Сделать пользователя юзером
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("setuserroleuser")]
        public async Task<IActionResult> SetUserRoleUser(
            string userId,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.SetUserRoleUser(
                userId,
                cancellationToken));
        }

        /// <summary>
        /// Сделать пользователя модератором
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("setuserrolemoderator")]
        public async Task<IActionResult> SetUserRoleModerator(
            string userId,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.SetUserRoleModerator(
                userId,
                cancellationToken));
        }

        /// <summary>
        /// Сделать пользователя админом
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("setuserroleadmin")]
        public async Task<IActionResult> SetUserRoleAdmin(
            string userId,
            CancellationToken cancellationToken)
        {
            return Ok(await _identityService.SetUserRoleAdmin(
                userId,
                cancellationToken));
        }
    }
}