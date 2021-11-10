using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts.Exceptions;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Зарегистрировать пользователя в Identity
        /// </summary>
        /// <param name="dto">DTO с данными пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<IdentityUserCreateResponseDto> CreateUser(
            IdentityUserCreateRequestDto dto, 
            CancellationToken cancellationToken = default)
        {
            // Проверка, существует ли такой пользователь в базе
            var existedUser = await _userManager
                .FindByEmailAsync(
                dto.Email);
            if (existedUser != null)
            {
                throw new ConflictException("Пользователь с таким Email уже существует");
            }

            // Создаем пользователя
            var identityUser = new IdentityUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            // Помещаем его в базу
            var identityResult = await _userManager
                .CreateAsync(
                    identityUser,
                    dto.Password);

            // Если удачно, то возвращаем положительный ответ
            if (identityResult.Succeeded)
            {
                await _userManager
                    .AddToRoleAsync(
                        identityUser,
                        dto.Role);

                return new IdentityUserCreateResponseDto
                {
                    UserId = identityUser.Id,
                    IsSuccess = true
                };

                // TODO нотификация по Email - подключить
            }

            // Иначе - отрицательный
            return new IdentityUserCreateResponseDto
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