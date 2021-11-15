using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Validators;
using System.Linq;
using sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests;
using Sev1.Advertisements.AppServices.Exceptions.Advertisement;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.AppServices.Exceptions.Category;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementCreatedResponse> Create(
            AdvertisementCreateRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementCreateRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new AdvertisementCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Возвращаем Id пользователя
            var userId = _userProvider.GetUserId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new NoRightsException("Нет создателя объявления!");
            }

            // Проверка категории на существование
            var category = await _categoryRepository.FindById(
                request.CategoryId,
                cancellationToken);
            if (category is null)
            {
                throw new CategoryNotFoundException(request.CategoryId);
            }

            // Если категория удалена
            if (category.IsDeleted)
            {
                throw new CategoryNotFoundException(request.CategoryId);
            }

            // Проверка, существует ли регион с таким идентификатором
            var region = await _regionRepository.FindById(
                request.RegionId,
                cancellationToken);
            if (region == null)
            {
                throw new RegionNotFoundException(request.RegionId);
            }

            // Создаёт доменную сущность нового объявления
            var advertisement = _mapper.Map<Domain.Advertisement>(request);

            // Дополняет сущность
            advertisement.IsDeleted = false; // не используется, т.к. есть Status // TODO убрать
            advertisement.CreatedAt = DateTime.UtcNow;
            advertisement.Category = category;
            advertisement.OwnerId = userId;
            advertisement.Status = AdvertisementStatus.Active;

            // Добавляем таги
            await AddTags(
                advertisement,
                request.TagBodies,
                cancellationToken);

            // Сохраняем в базе
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);

            // Возвращаем идентификатор созданного объявления
            return new AdvertisementCreatedResponse() 
            {
                Id = advertisement.Id
            };
        }
    }
}