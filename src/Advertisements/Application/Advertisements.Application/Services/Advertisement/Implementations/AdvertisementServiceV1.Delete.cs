using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Удаляет объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Delete(
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

            // Достаем объявление из базы
            var advertisement = await _advertisementRepository.FindByIdWithTagsInclude(
                id,
                cancellationToken);

            // Если объявления с таким Id нет, то выход
            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Пользователь может удалять объявление:
            //  - если он администратор;
            //  - если он модератор;
            //  - если он создал это объявление.
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            if(!(isAdministrator||isModerator||isOwnerId))
            {
                throw new NoRightsException("Не хватает прав удалить объявление!");
            }

            // Объявленние не удаляется, а лишь помечается удаленным
            advertisement.Status = AdvertisementStatus.Deleted;

            // Обновляется дата редактирования
            advertisement.UpdatedAt = DateTime.UtcNow;

            // Сохраняет изменения в базу
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}