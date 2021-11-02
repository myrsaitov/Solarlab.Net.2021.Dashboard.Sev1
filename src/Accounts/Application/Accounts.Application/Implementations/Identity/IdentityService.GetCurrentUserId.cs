using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
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
