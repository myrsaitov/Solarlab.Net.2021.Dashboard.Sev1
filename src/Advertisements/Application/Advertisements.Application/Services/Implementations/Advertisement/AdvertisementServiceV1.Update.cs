using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Services.Validators.Advertisement;
using System.Linq;
using Sev1.Advertisements.Application.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Domain;
using Sev1.Advertisements.Application.Exceptions.Category;

namespace Sev1.Advertisements.Application.Services.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Обновляет объявление
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<int> Update(
            AdvertisementUpdateRequest request,
            CancellationToken cancellationToken)
        {
          
            // Fluent Validation
            var validator = new AdvertisementUpdateDtoValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new AdvertisementUpdateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
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

            // TODO Mapper
            advertisement.Title = request.Title;
            advertisement.Body = request.Body;
            advertisement.Price = request.Price;
            advertisement.CategoryId = request.CategoryId;

            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;

            var category = await _categoryRepository.FindById(
                advertisement.CategoryId,
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(advertisement.CategoryId);
            }

            advertisement.Category = category;
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

            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);

            return advertisement.Id;
        }
    }
}