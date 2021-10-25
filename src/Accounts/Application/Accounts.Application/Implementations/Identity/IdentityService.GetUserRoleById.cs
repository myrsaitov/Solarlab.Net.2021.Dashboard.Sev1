using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {

        public async Task<string> GetUserRoleById(
            string userId, 
            CancellationToken cancellationToken = default)
        {
            var isAdmin = await IsInRole(userId, RoleConstants.AdminRole, cancellationToken);
            if (isAdmin)
            {
                return RoleConstants.AdminRole.ToString().ToLower();
            }

            var isModerator = await IsInRole(userId, RoleConstants.ModeratorRole, cancellationToken);
            if (isModerator)
            {
                return RoleConstants.ModeratorRole.ToString().ToLower();
            }

            return RoleConstants.UserRole.ToString().ToLower();
        }
    }
}
