using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.Identity.Responses;
using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Зарегистрировать пользователя в Identity
        /// </summary>
        /// <param name="request">DTO с данными пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<IdentityUserCreateResponse> CreateUser(
            IdentityUserCreateRequest request, 
            CancellationToken cancellationToken = default)
        {
            //TODO validator

            // Проверка, существует ли такой пользователь в базе
            var existedUser = await _userManager
                .FindByEmailAsync(
                request.EMail);
            if (existedUser != null)
            {
                throw new ConflictException("Пользователь с таким Email уже существует");
            }

            // Создаем пользователя
            var identityUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.EMail
            };

            // Помещаем его в базу
            var identityResult = await _userManager
                .CreateAsync(
                    identityUser,
                    request.Password);

            // Если удачно, то возвращаем положительный ответ
            if (identityResult.Succeeded)
            {
                await _userManager
                    .AddToRoleAsync(
                        identityUser,
                        request.Role);

                return new IdentityUserCreateResponse
                {
                    UserId = identityUser.Id,
                    IsSuccess = true
                };

                // TODO нотификация по E-mail - подключить
            }

            // Иначе - отрицательный
            return new IdentityUserCreateResponse
            {
                IsSuccess = false,
                Errors = identityResult
                    .Errors
                    .Select(x => x.Description)
                    .ToArray()
            };
        }
    }
}