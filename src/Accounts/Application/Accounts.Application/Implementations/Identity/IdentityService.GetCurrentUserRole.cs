using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<string> GetCurrentUserRole(
            CancellationToken cancellationToken = default)
        {
            var currentUserId = await GetCurrentUserId(cancellationToken);
            if (currentUserId == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            var isAdmin = await IsInRole(currentUserId, RoleConstants.AdminRole, cancellationToken);
            if(isAdmin)
            {
                return RoleConstants.AdminRole.ToString().ToLower();
            }

            var isModerator = await IsInRole(currentUserId, RoleConstants.ModeratorRole, cancellationToken);
            if(isModerator)
            {
                return RoleConstants.ModeratorRole.ToString().ToLower();
            }

            return RoleConstants.UserRole.ToString().ToLower();
        }
    }
}
