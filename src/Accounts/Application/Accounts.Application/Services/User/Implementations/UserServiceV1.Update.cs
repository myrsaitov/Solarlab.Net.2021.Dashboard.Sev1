using Sev1.Accounts.AppServices.Contracts.User.Requests;
using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.Domain.Base.Exceptions;
using Sev1.Accounts.AppServices.Services.User.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Обновляет данные пользователя
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Update(
            UserUpdateRequest request, 
            CancellationToken cancellationToken)
        {
            // Возвращает пользователя по идентификатору
            var domainUser = await _userRepository
                .FindById(
                request.Id,
                cancellationToken);

            // Исключение, если пользователь не найден
            if (domainUser == null)
            {
                throw new UserNotFoundException($"Пользователь с идентификатором {request.Id} не найден");
            }

            // Проверка, существует ли регион с таким идентификатором
            var validated = await _regionValidateApiClient
                .RegionValidate(
                    request.RegionId);
            if (!validated)
            {
                throw new NotFoundException("Не найдено!");
            }

            // Возвращает идентификатор авторизированного пользователя
            var currentUserId = _identityService
                .GetCurrentUserId(cancellationToken);

            // Исключение, если пользователь не найден
            if (currentUserId == null)
            {
                throw new NoRightsException("Пользователь не найден!");
            }
            
            // Если идентификаторы не совпадают
            if (domainUser.Id != currentUserId)
            {
                throw new NoRightsException("Нет прав");
            }

            // Обновляет данные
            // TODO mapper _mapper.Map<Register.Response>(response);
            domainUser.FirstName = request.FirstName;
            domainUser.LastName = request.LastName;
            domainUser.MiddleName = request.MiddleName;
            domainUser.PhoneNumber = request.PhoneNumber;
            domainUser.UpdatedAt = DateTime.UtcNow;

            // Сохраняет в базе
            await _userRepository.Save(domainUser, cancellationToken);
        }
    }
}