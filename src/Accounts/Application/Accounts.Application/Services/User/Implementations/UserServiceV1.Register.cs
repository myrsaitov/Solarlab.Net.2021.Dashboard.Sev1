using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Validators;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.AppServices.Services.User.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Domain.Base.Exceptions;
using Sev1.Accounts.Contracts.Contracts.User.Responses;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserIdResponse> Register(
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

            // Проверка, существует ли регион с таким идентификатором
            var validated = await _regionValidateApiClient
                .RegionValidate(
                    request.RegionId);
            if (!validated)
            {
                throw new NotFoundException("Не найдено!");
            }

            // Регистрация в сервисе Identity
            var response = await _identityService.CreateUser(
                _mapper.Map<IdentityUserCreateRequest>(request),
                cancellationToken);

            // Если регистрация прошла успешно
            if (response.IsSuccess)
            {
                // Создает сущность нового доменного пользователя
                var newUser = _mapper.Map<Domain.User>(request);
                newUser.Id = response.UserId;
                newUser.CreatedAt = DateTime.UtcNow;

                // Сохраняем нового доменного пользователя в базе
                await _userRepository.Save(newUser, cancellationToken);

                // Возвращаем идентификатор нового доменного пользователя
                return new UserIdResponse() 
                {
                    UserId = response.UserId 
                };
            }

            // Исключение при неудачной регистрации
            throw new UserRegisteredException(
                string.Join(';', response.Errors));
        }
    }
}