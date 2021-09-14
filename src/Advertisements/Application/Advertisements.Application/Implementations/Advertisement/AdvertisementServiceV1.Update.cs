using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces;
using Sev1.Advertisements.Application.Contracts.Tag;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task<int> Update(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var advertisement = await _advertisementRepository.FindByIdWithUserAndCategoryAndTags(
                request.Id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(request.Id);
            }





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

            if (request.TagBodies is not null)
            {
                foreach (string body in request.TagBodies)
                {
                    if (body.Length > 0)
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

            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);

            return advertisement.Id;
        }
    }
}