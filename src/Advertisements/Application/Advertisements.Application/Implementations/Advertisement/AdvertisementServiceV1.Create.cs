﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Validators.Advertisement;
using System.Linq;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Contracts.Exception;
using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Create(
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
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
                model.CategoryId,
                cancellationToken);

            // Если категория не существует
            if (category is null)
            {
                throw new CategoryNotFoundException(model.CategoryId);
            }

            // Если категория удалена
            if (category.IsDeleted)
            {
                throw new CategoryNotFoundException(model.CategoryId);
            }

            // Дополняем модель
            var advertisement = _mapper.Map<Domain.Advertisement>(model);
            advertisement.IsDeleted = false;
            advertisement.CreatedAt = DateTime.UtcNow;
            advertisement.Category = category;
            advertisement.OwnerId = userId;
            advertisement.Status = AdvertisementStatus.Active;

            // Добавляем таги
            await AddTags(
                advertisement,
                model.TagBodies,
                cancellationToken);

            // Сохраняем в базе
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}