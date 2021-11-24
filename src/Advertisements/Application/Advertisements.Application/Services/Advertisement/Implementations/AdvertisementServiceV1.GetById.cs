using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;
using Sev1.Advertisements.Domain.Base.Exceptions;
using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementGetResponse> GetById(
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

            // Достаем объявление из базы по идентификатору
            var advertisement = await _advertisementRepository.FindByIdWithCategoriesAndTagsAndUserFiles(
                id,
                cancellationToken);

            // Если объявление с таким идентификатором не существует, то исключение
            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Объявление активно?
            var isActive = advertisement.Status == AdvertisementStatus.Active;

            // Если объявление активно, то маппим сущность на DTO и возвращаем
            if (isActive)
            {
                return _mapper.Map<AdvertisementGetResponse>(advertisement);
            }

            // Иначе:
            // Пользователь может просматривать неактивное объявление:
            //  - если он администратор;
            //  - если он модератор;
            //  - если он создал это объявление.
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            if (!(isAdministrator || isModerator || isOwnerId))
            {
                throw new NoRightsException("Не хватает прав просмотреть неактивное объявление!");
            }

            // Маппим сущность на DTO и возвращаем
            return _mapper.Map<AdvertisementGetResponse>(advertisement);
        }
    }
}