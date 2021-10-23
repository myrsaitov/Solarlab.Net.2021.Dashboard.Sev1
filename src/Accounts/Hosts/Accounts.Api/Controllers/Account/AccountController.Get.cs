using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [Authorize]
        [HttpPost("currentuserid")]
        public async Task<IActionResult> GetCurrentUserId(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);
            
            return Ok(domainUser.Id);
        }

        [Authorize]
        [HttpPost("currentuser")]
        public async Task<IActionResult> GetCurrentUser(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);

            return Ok(domainUser);
        }

        [Authorize]
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