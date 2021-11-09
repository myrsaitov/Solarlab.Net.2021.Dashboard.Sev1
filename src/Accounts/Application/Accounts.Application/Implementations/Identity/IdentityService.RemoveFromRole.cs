﻿using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Убирает пользователя из указанной роли
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="role">Роль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task RemoveFromRole(
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

            // Удаляем пользователя и роли
            await _userManager.RemoveFromRoleAsync(
                identityUser,
                role);
        }
    }
}