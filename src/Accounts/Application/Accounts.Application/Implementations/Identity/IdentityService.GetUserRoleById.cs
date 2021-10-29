using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Возвращает роль пользователя по его Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetUserRoleById(
            string userId, 
            CancellationToken cancellationToken = default)
        {
            // TODO переделать попроще
            var isAdmin = await IsInRole(
                userId,
                RoleConstants.Admin.ToString(),
                cancellationToken);
            if (isAdmin)
            {
                return RoleConstants.Admin.ToString().ToLower();
            }

            var isModerator = await IsInRole(
                userId,
                RoleConstants.Moderator.ToString(),
                cancellationToken);
            if (isModerator)
            {
                return RoleConstants.Moderator.ToString().ToLower();
            }

            return RoleConstants.User.ToString().ToLower();
        }
    }
}
