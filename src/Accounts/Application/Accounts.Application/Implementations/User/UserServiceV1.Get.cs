using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Application.Exceptions.User;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Возвращает пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<Domain.User> Get(
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

            // Возвращат пользователя
            return domainUser;
        }
    }
}