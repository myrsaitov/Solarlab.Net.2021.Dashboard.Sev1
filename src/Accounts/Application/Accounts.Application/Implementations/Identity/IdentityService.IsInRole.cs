using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<bool> IsInRole(string userId, string role, CancellationToken cancellationToken = default)
        {
            var identityUser = await _userManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }
            return await _userManager.IsInRoleAsync(identityUser, role);
        }
    }
}
