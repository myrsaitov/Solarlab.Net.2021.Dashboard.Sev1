using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<IEnumerable<string>> GetCurrentUserRoles(
            CancellationToken cancellationToken = default)
        {
            var currentUserId = GetCurrentUserId(cancellationToken);
            if (currentUserId == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            var user = await _userManager.FindByIdAsync(currentUserId);
            var userRoles = await _userManager.GetRolesAsync(user);

            return userRoles;
        }
    }
}