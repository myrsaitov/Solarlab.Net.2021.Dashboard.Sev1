using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [Authorize]
        [HttpPost("user")]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            var domainUser = await _userService.Get(currentUserId, cancellationToken);
            
            return Ok(domainUser);
        }
    }
}