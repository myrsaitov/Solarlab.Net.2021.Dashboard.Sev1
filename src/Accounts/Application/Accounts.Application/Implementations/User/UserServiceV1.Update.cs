using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Exceptions.User;
using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        public async Task Update(
            Update.Request request, 
            CancellationToken cancellationToken)
        {
            var domainUser = await _userRepository.FindById(request.Id, cancellationToken);
            if (domainUser == null)
            {
                throw new UserNotFoundException($"Пользователь с идентификатором {request.Id} не найден");
            }

            var currentUserId = await _identityService.GetCurrentUserId(cancellationToken);
            if (domainUser.Id != currentUserId)
            {
                throw new NoRightsException("Нет прав");
            }

            domainUser.FirstName = request.FirstName;
            domainUser.LastName = request.LastName;
            domainUser.MiddleName = request.MiddleName;
            domainUser.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Save(domainUser, cancellationToken);
        }
    }
}