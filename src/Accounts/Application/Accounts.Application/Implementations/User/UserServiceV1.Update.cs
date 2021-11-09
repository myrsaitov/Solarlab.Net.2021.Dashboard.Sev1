using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Exceptions.User;
using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Contracts.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Обновление данных о пользователе
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Update(
            Update.Request request, 
            CancellationToken cancellationToken)
        {
            var domainUser = await _userRepository.FindById(request.Id, cancellationToken);
            if (domainUser == null)
            {
                throw new UserNotFoundException($"Пользователь с идентификатором {request.Id} не найден");
            }

            var currentUserId = _identityService.GetCurrentUserId(cancellationToken);
            if(currentUserId == null)
            {
                throw new NoRightsException("Пользователь не найден!");
            }
            
            if (domainUser.Id != currentUserId)
            {
                throw new NoRightsException("Нет прав");
            }

            domainUser.FirstName = request.FirstName;
            domainUser.LastName = request.LastName;
            domainUser.MiddleName = request.MiddleName;
            domainUser.PhoneNumber = request.PhoneNumber;
            domainUser.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Save(domainUser, cancellationToken);
        }
    }
}