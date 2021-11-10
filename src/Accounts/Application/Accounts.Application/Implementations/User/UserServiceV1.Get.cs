using Sev1.Accounts.Application.Exceptions.User;
using Sev1.Accounts.Application.Interfaces.User;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        public async Task<Domain.User> Get(
            string userId, 
            CancellationToken cancellationToken)
        {
            var domainUser = await _userRepository
                .FindById(
                    userId,
                    cancellationToken);
            if (domainUser == null)
            {
                throw new UserNotFoundException($"Пользователь с идентификатором {userId} не найден");
            }

            return domainUser;
        }
    }
}