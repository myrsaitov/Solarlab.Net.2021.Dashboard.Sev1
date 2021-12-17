using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;
using Sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Восстановить объявление
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Restore(
            int? id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new AdvertisementIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // TODO Нужно сделать, чтобы при восстановлении
            // объявления обновлялись счетчики тагов
            var advertisement = await _advertisementRepository.FindByIdWithTagsInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Пользователь может восстановить объявление:
            //  - если он создал это объявление;
            //  - модератор и администратор не могут это сделать;
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            if (!isOwnerId)
            {
                throw new NoRightsException("Вы не создали это объявление!");
            }

            // Восстановливает объявление
            advertisement.Status = AdvertisementStatus.Active;

            // Сохраняет изменения в базу
            advertisement.UpdatedAt = DateTime.UtcNow;
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}