using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts.Exceptions.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Возвращает роли авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetCurrentUserRoles(
            CancellationToken cancellationToken = default)
        {
            // Возвращаем идентификатор авторизированного пользователя
            var currentUserId = GetCurrentUserId(cancellationToken);
            if (currentUserId == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            // Возвращаем авторизированного пользователя по его идентификатору
            var user = await _userManager.FindByIdAsync(currentUserId);

            // Возвращаем роли пользователя
            return await _userManager.GetRolesAsync(user);
        }
    }
}