using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using System.Linq;
using Sev1.Advertisements.AppServices.Contracts.Advertisement.Requests;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;
using Sev1.Advertisements.Domain.Base.Exceptions;
using sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.AppServices.Services.Region.Exceptions;
using Sev1.Advertisements.AppServices.Services.Category.Exceptions;
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

            var advertisement = await _advertisementRepository.FindByIdWithCategoriesAndTags(
                request.Id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(request.Id);
            }

            // Обычный пользователь может обновлять статус только свои собственные объявления
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            if (!isOwnerId)
            {
                throw new NoRightsException("Вы не создали это объявление!");
            }

            // Модератор может только ставить статус "Не соответсвует нормам"
            var isModerator = _userProvider.IsInRole("Moderator");
            if ((request.Status != AdvertisementStatus.NotAllowed)&&
                (isModerator))
            {
                throw new ConflictException("Вы не можете установить этот статус!");
            }

            // Администратор может только ставить статус "Приостановлено",
            // если до этого было "Не соответсвует нормам"
            var isAdministrator = _userProvider.IsInRole("Administrator");
            if (((advertisement.Status != AdvertisementStatus.NotAllowed) ||
                (request.Status != AdvertisementStatus.Stopped)) &&
                (isAdministrator))
            {
                throw new ConflictException("Вы не можете установить этот статус!");
            }

            // Обычный пользователь не может изменить
            // установленный модератором статус "Не соответсвует нормам"
            var isUser = _userProvider.IsInRole("User");
            if ((advertisement.Status == AdvertisementStatus.NotAllowed) &&
                (isUser))
            {
                throw new ConflictException("Вы не можете изменить этот статус!");
            }

            // Обновляет статус
            advertisement.Status = request.Status;

            // Обновляет время редактирования
            advertisement.UpdatedAt = DateTime.UtcNow;

            // Сохраняет в базе
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);

            // Возвращаем идентификатор обновленного объявления
            return new AdvertisementUpdatedResponse()
            {
                Id = advertisement.Id
            };
        }
    }
}