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
        public async Task<AdvertisementUpdatedResponse> Update(
            AdvertisementUpdateRequest request,
            CancellationToken cancellationToken)
        {
          
            // Fluent Validation
            var validator = new AdvertisementUpdateDtoValidator();
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

            // Обычный пользователь может обновлять только свои собственные объявления
            // Модератор и админ не могут редактировать, только удалять
            var isOwnerId = (advertisement.OwnerId == _userProvider.GetUserId());
            if (!isOwnerId)
            {
                throw new NoRightsException("Вы не создали это объявление!");
            }

            // Проверка, существует ли регион с таким идентификатором
            var region = await _regionRepository.FindById(
                request.RegionId,
                cancellationToken);
            if (region == null)
            {
                throw new RegionNotFoundException(request.RegionId);
            }

            // Здесь использовать Mapper нельзя,
            // т.к. маппер создает новую сущность,
            // и в базу ее не положить заместо старой.
            // Нужно редактировать старую.
            advertisement.Title = request.Title;
            advertisement.Body = request.Body;
            advertisement.Price = request.Price;
            advertisement.CategoryId = request.CategoryId;
            advertisement.Address = request.Address;
            advertisement.RegionId = request.RegionId;
            advertisement.Status = request.Status;

            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;

            // Ищет категорию в базе
            var category = await _categoryRepository.FindById(
                advertisement.CategoryId,
                cancellationToken);
            if (category == null)
            {
                throw new CategoryNotFoundException(advertisement.CategoryId);
            }

            // Если категория существует, то присваивает объявлению
            advertisement.Category = category;

            // Если переданы таги
            if (advertisement.Tags == null)
            {
                advertisement.Tags = new List<Domain.Tag>();
            }
            advertisement.Tags.Clear();

            // Добавляем таги
            await AddTags(
                advertisement,
                request.TagBodies,
                cancellationToken);

            // Сохраняем в базу
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
}