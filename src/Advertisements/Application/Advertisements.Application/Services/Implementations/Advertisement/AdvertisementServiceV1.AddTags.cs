using System.Threading;
using System.Threading.Tasks;
using System;
using Sev1.Advertisements.AppServices.Services.Interfaces.Advertisement;
using System.Collections.Generic;
using Sev1.Advertisements.Contracts.Contracts.Tag.Requests;

namespace Sev1.Advertisements.AppServices.Services.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Добавить таги к объявлению
        /// </summary>
        /// <param name="advertisement">Объект объявления</param>
        /// <param name="TagBodies">Массив тагов</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task AddTags(
            Domain.Advertisement advertisement,
            string[] TagBodies,
            CancellationToken cancellationToken)
        {
            // Добавляем таги
            if (TagBodies is not null)
            {
                advertisement.Tags = new List<Domain.Tag>();
                foreach (string body in TagBodies)
                {
                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        var tag = await _tagRepository.FindWhere(
                            a => a.Body == body,
                            cancellationToken);

                        if (tag == null)
                        {
                            var tagRequest = new TagCreateRequest()
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
        }
    }
}