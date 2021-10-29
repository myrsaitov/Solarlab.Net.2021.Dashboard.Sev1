using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<GetAutorizedStatusResponse> GetAutorizedStatus(
            CancellationToken cancellationToken = default)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            var currentUserId = _userManager.GetUserId(claimsPrincipal);
            var roles = await GetCurrentUserRoles(cancellationToken);

            return new GetAutorizedStatusResponse
            {
                UserId = currentUserId,
                Roles = roles
            };
        }
    }
}
