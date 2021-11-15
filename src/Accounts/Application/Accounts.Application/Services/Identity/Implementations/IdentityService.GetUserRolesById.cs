using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Возвращает роль пользователя по его Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetUserRolesById(
            string userId, 
            CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            return userRoles;
        }
    }
}
