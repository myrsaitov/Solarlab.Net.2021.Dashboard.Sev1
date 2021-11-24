using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using System.Linq;
using Sev1.Advertisements.AppServices.Contracts.Advertisement.Requests;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;
using Sev1.Advertisements.Domain.Base.Exceptions;
using sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Обновляет объявление
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementUpdatedResponse> UpdateStatus(
            AdvertisementUpdateStatusRequest request,
            CancellationToken cancellationToken)
        {
          
            // Fluent Validation
            var validator = new AdvertisementUpdateStatusDtoValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new AdvertisementUpdateRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var advertisement = await _advertisementRepository.FindByIdWithCategoriesAndTagsAndUserFiles(
                request.Id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(request.Id);
            }

            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            var isUser = _userProvider.IsInRole("User");

            // Администратор может только ставить статус "Приостановлено",
            // если до этого было "Не соответсвует нормам"
            if (isAdministrator)
            {
                if (((advertisement.Status != AdvertisementStatus.NotAllowed) ||
                    (request.Status != AdvertisementStatus.Stopped)))
                {
                    throw new ConflictException("Вы не можете установить этот статус!");
                }
                else
                {
                    // Обновляет статус и время редактирования
                    advertisement.Status = request.Status;
                    advertisement.UpdatedAt = DateTime.UtcNow;
                    // Сохраняет в базе
                    await _advertisementRepository.Save(
                        advertisement,
                        cancellationToken);
                    // Возвращаем идентификатор обновленного объявления
                    return new AdvertisementUpdatedResponse()
                    {
                        Status = advertisement.Status
                    };
                }
            }

            // Модератор может только ставить статус "Не соответсвует нормам"
            else if (isModerator)
            {
                if ((request.Status != AdvertisementStatus.NotAllowed))
                {
                    throw new ConflictException("Вы не можете установить этот статус!");
                }
                else
                {
                    // Обновляет статус и время редактирования
                    advertisement.Status = request.Status;
                    advertisement.UpdatedAt = DateTime.UtcNow;
                    // Сохраняет в базе
                    await _advertisementRepository.Save(
                        advertisement,
                        cancellationToken);
                    // Возвращаем идентификатор обновленного объявления
                    return new AdvertisementUpdatedResponse()
                    {
                        Status = advertisement.Status
                    };
                }
            }

            // Обычный пользователь может обновлять статус только свои собственные объявления
            else if (isOwnerId)
            {
                if (!isOwnerId)
                {
                    throw new NoRightsException("Вы не создали это объявление!");
                }
                else
                {
                    // Обычный пользователь не может изменить
                    // установленный модератором статус "Не соответсвует нормам"
                    if ((advertisement.Status == AdvertisementStatus.NotAllowed) &&
                        (isUser))
                    {
                        throw new ConflictException("Вы не можете изменить этот статус!");
                    }

                    // Обновляет статус и время редактирования
                    advertisement.Status = request.Status;
                    advertisement.UpdatedAt = DateTime.UtcNow;
                    // Сохраняет в базе
                    await _advertisementRepository.Save(
                        advertisement,
                        cancellationToken);
                    // Возвращаем идентификатор обновленного объявления
                    return new AdvertisementUpdatedResponse()
                    {
                        Status = advertisement.Status
                    };
                }
            }
            else
            {
                throw new NoRightsException("Нет прав обновить статус!");
            }
        }
    }
}