using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<string> AddToAdminRole(
            string userId,
            CancellationToken cancellationToken = default)
        {
            // Получить роль текущего пользователя
            var currentUserRole = await GetCurrentUserRole();

            // Если его роль админ, то добавлем роль админа
            if ((currentUserRole == RoleConstants.Admin.ToString().ToLower()))
            {
                // Вычисляем пользователя по Id
                var identityUser = await _userManager.FindByIdAsync(userId);
                if (identityUser == null)
                {
                    throw new IdentityUserNotFoundException("Пользователь не найден");
                }

                // Удаляем роль модератора
                await _userManager.RemoveFromRoleAsync(
                    identityUser,
                    RoleConstants.Moderator.ToString());

                // Удаляем роль юзера
                await _userManager.RemoveFromRoleAsync(
                    identityUser,
                    RoleConstants.User.ToString());

                // Ставим роль админа
                await _userManager.AddToRoleAsync(
                    identityUser, 
                    RoleConstants.Admin.ToString());
            }
            else
            {
                throw new NoRightsException("Не хватает прав изменить роль пользователя!");
            }

            // Вернуть результат
            return await GetUserRoleById(userId);
        }
    }
}
