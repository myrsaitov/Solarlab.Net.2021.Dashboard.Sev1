using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Identity;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [Authorize]
        [HttpPost("isadmin")]
        public async Task<IActionResult> IsAdmin(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var isAdmin = await _identityService.IsInRole(currentUserId, RoleConstants.AdminRole, cancellationToken);

            return Ok(isAdmin);
        }
    }
}