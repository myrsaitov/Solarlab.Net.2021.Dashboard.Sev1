using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.AppServices.Services.Interfaces.Identity;

namespace Sev1.Accounts.AppServices.Services.Implementations.Identity
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
