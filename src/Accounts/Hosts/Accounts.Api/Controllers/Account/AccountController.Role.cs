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
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            
            var isAdmin = await _identityService.IsInRole(currentUserId, RoleConstants.AdminRole, cancellationToken);
            if(isAdmin)
            {
                return Ok(RoleConstants.AdminRole.ToString().ToLower());
            }
            
            var isModerator = await _identityService.IsInRole(currentUserId, RoleConstants.ModeratorRole, cancellationToken);
            if (isModerator)
            {
                return Ok(RoleConstants.ModeratorRole.ToString().ToLower());
            }

            return Ok(RoleConstants.UserRole.ToString().ToLower());
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
            var isAdmin = await _identityService.IsInRole(userId, RoleConstants.AdminRole, cancellationToken);
            if (isAdmin)
            {
                return Ok(RoleConstants.AdminRole.ToString().ToLower());
            }

            var isModerator = await _identityService.IsInRole(userId, RoleConstants.ModeratorRole, cancellationToken);
            if (isModerator)
            {
                return Ok(RoleConstants.ModeratorRole.ToString().ToLower());
            }

            return Ok(RoleConstants.UserRole.ToString().ToLower());
        }

        /// <summary>
        /// Сделать пользователя модератором
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("setuserasmoderator")]
        public async Task<IActionResult> SetUserAsModerator(
            string userId,
            CancellationToken cancellationToken)
        {
            /*var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);

            var isAdmin = await _identityService.IsInRole(currentUserId, RoleConstants.AdminRole, cancellationToken);
            if (isAdmin)
            {
                return Ok(RoleConstants.AdminRole.ToString().ToLower());
            }

            var isModerator = await _identityService.IsInRole(currentUserId, RoleConstants.ModeratorRole, cancellationToken);
            if (isModerator)
            {
                return Ok(RoleConstants.ModeratorRole.ToString().ToLower());
            }*/

            return Ok();
        }
    }
}