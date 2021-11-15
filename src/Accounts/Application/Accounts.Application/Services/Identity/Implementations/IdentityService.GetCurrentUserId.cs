using System.Threading;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        public string GetCurrentUserId(CancellationToken cancellationToken = default)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            return _userManager.GetUserId(claimsPrincipal);
        }
    }
}