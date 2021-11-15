using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Interfaces.Advertisement;
using Sev1.Advertisements.AppServices.Services.Validators.Advertisement;
using Sev1.Advertisements.AppServices.Exceptions.Advertisement;
using Sev1.Advertisements.AppServices.Exceptions.Domain;
using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.AppServices.Services.Implementations.Advertisement
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

            // TODO Сделать нормальный подсчет количества Tags
            // Убираем из количества объявлений по данному тагу единицу
            if (advertisement.Tags is not null)
            {
                foreach (var tag in advertisement.Tags)
                {
                    if (tag.Count > 0)
                    {
                        tag.Count -= 1;
                        await _tagRepository.Save(
                            tag,
                            cancellationToken);
                    }
                }
            }

            // Сохраняет изменения в базу
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}