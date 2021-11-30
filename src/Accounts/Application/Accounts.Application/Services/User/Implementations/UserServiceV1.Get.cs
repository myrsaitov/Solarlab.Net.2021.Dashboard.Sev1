using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Contracts.Contracts.User.Responses;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Возвращает пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserGetResponse> Get(
            string userId, 
            CancellationToken cancellationToken)
        {
            // Возвращает пользователя по идентификатору
            var domainUser = await _userRepository
                .FindById(
                    userId,
                    cancellationToken);

            // Исключение, если пользователь не найден
            if (domainUser == null)
            {
                throw new UserNotFoundException($"Пользователь с идентификатором {userId} не найден");
            }

            // Маппит и возвращает ответ
            return _mapper.Map<UserGetResponse>(domainUser);
        }

        /// <summary>
        /// Возвращает DTO авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserGetResponse> GetCurrentUser(
            CancellationToken cancellationToken)
        {
            // Определяет идентификатор авторизированного пользователя
            var currentUserId = _identityService.GetCurrentUserId(cancellationToken);
            
            // Возвращает доменную сущность авторизированного пользователя из БД
            var domainUser = await Get(
                    currentUserId,
                    cancellationToken);

            // Маппит и возвращает ответ
            return _mapper.Map<UserGetResponse>(domainUser);
        }
    }
}