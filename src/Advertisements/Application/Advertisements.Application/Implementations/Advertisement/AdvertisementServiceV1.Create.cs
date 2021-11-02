using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Contracts.Tag;
using Sev1.Advertisements.Application.Validators.Advertisement;
using System.Linq;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Domain.Exceptions;

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

            // Дополняем модель - Id пользователя, который создал объявление
            model.OwnerId = userId;

            // Проверка категории на существование
            var category = await _categoryRepository.FindById(
                model.CategoryId,
                cancellationToken);

            if (category is null)
            {
                throw new CategoryNotFoundException(model.CategoryId);
            }

            // Дополняем модель
            var advertisement = _mapper.Map<Domain.Advertisement>(model);
            advertisement.IsDeleted = false;
            advertisement.CreatedAt = DateTime.UtcNow;
            advertisement.Category = category;

            // Добавляем таги
            if (model.TagBodies is not null)
            {
                advertisement.Tags = new List<Domain.Tag>();
                foreach (string body in model.TagBodies)
                {
                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        var tag = await _tagRepository.FindWhere(
                            a => a.Body == body,
                            cancellationToken);

                        if (tag == null)
                        {
                            var tagRequest = new TagCreateDto()
                            {
                                Body = body
                            };

                            tag = _mapper.Map<Domain.Tag>(tagRequest);
                            tag.CreatedAt = DateTime.UtcNow;
                            tag.Count = 1;

                            await _tagRepository.Save(
                                tag, 
                                cancellationToken);
                        }
                        else
                        {
                            // TODO Переделать с поиском в базе, учесть удаленные объявления
                            tag.Count += 1;
                            await _tagRepository.Save(tag, cancellationToken);
                        }

                        advertisement.Tags.Add(tag);
                    }
                }
            }

            // Сохраняем в базе
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}