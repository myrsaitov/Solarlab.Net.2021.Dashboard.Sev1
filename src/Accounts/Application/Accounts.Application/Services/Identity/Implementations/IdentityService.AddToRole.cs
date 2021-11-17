using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;
using Sev1.Accounts.AppServices.Services.Identity.Exceptions;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        // TODO проработать тут
        
        /// <summary>
        /// Добавляет пользователя к указанной роли
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="role">Роль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task AddToRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default)
        {
            // Вычисляем пользователя по Id
            var identityUser = await _userManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            // Проверяем, есть ли роль в списке ролей
            var isExist = await _roleManager.RoleExistsAsync(role);
            if (!isExist)
            {
                throw new RoleNotFoundException("Роль не найдена");
            }

            // Добавляем роль
            await _userManager.AddToRoleAsync(
                identityUser,
                role);
        }
    }
}