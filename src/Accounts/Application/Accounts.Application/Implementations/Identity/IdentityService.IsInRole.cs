using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts.Exceptions.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Проверяет, имеет ли пользователь указанную роль
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="role">Проверяемая роль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<bool> IsInRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default)
        {
            // Возвращаем Identity пользователя по его идентификатору
            var identityUser = await _userManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            // Проверяем роль
            return await _userManager.IsInRoleAsync(identityUser, role);
        }
    }
}