using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Exceptions.User;
using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Application.Validators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Сервис регистрации нового пользователя
        /// </summary>
        /// <param name="userRegisterDto">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<string> Register(
            UserRegisterDto userRegisterDto, 
            CancellationToken cancellationToken)
        {
            RegisterRequestValidator validator = new();
            var result = await validator
                .ValidateAsync(userRegisterDto);

            if (!result.IsValid)
            {
                throw new UserRegisteredException(
                    string.Join(';', result.Errors.Select(x => x.ErrorMessage)));
            }

            // Регистрация в сервисе Identity
            var response = await _identityService.CreateUser(
                _mapper.Map<IdentityUserCreateRequestDto>(userRegisterDto),
                cancellationToken);

            if (response.IsSuccess)
            {
                //TODO mapper _mapper.Map<Domain.User>(registerRequest);
                var newUser = new Domain.User
                {
                    Id = response.UserId,
                    UserName = userRegisterDto.UserName,
                    FirstName = userRegisterDto.FirstName,
                    LastName = userRegisterDto.LastName,
                    MiddleName = userRegisterDto.MiddleName,
                    PhoneNumber = userRegisterDto.PhoneNumber,
                    CreatedAt = DateTime.UtcNow
                };

                // Сохраняем нового зарегистрированного пользователя в базе
                await _userRepository.Save(newUser, cancellationToken);

                // Возвращаем Id нового зарегистрированного пользователя
                return response.UserId;
            }

            // Исключение при неудачной регистрации
            throw new UserRegisteredException(
                string.Join(';', response.Errors));
        }
    }
}