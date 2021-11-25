using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Validators;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.AppServices.Services.User.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Contracts.Contracts.User.Responses;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserLoginResponse> Login(
            UserLoginRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            LoginRequestValidator validator = new();
            var result = await validator
                .ValidateAsync(request);

            // Если не прошли валидацию
            if (!result.IsValid)
            {
                throw new UserLoginException(
                    string.Join(';', result.Errors.Select(x => x.ErrorMessage)));
            }

            // Создание токена в сервисе Identity
            var res = await _identityService.CreateToken(
                request,
                cancellationToken);

            // Возвращает пользователя по идентификатору
            var domainUser = await _userRepository
                .FindById(
                    res.UserId,
                    cancellationToken);

            // Возвращает ответ
            return new UserLoginResponse()
            {
                Token = res.Token,
                UserId = res.UserId,
                Roles = res.Roles,
                UserName = domainUser.UserName,
                RegionId = domainUser.RegionId,
                EMail = request.EMail
            };
        }
    }
}