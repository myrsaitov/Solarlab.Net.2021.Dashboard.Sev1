using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Application.Validators;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Exceptions.User;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<string> Register(
            UserRegisterRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            RegisterRequestValidator validator = new();
            var result = await validator
                .ValidateAsync(request);

            // Если не прошли валидацию
            if (!result.IsValid)
            {
                throw new UserRegisteredException(
                    string.Join(';', result.Errors.Select(x => x.ErrorMessage)));
            }

            // Регистрация в сервисе Identity
            var response = await _identityService.CreateUser(
                _mapper.Map<IdentityUserCreateRequest>(request),
                cancellationToken);

            // Если регистрация прошла успешно
            if (response.IsSuccess)
            {
                //TODO mapper _mapper.Map<Domain.User>(registerRequest);
                var newUser = new Domain.User
                {
                    Id = response.UserId,
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    PhoneNumber = request.PhoneNumber,
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