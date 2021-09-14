using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Delete(
            int id,
            CancellationToken cancellationToken)
        {
            /*if (id is null)
            {
                throw new ArgumentNullException(nameof(request));
            }*/

            var advertisement = await _advertisementRepository.FindByIdWithUserAndTagsInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            advertisement.IsDeleted = true;
            advertisement.UpdatedAt = DateTime.UtcNow;

            // TODO Сделать нормальный подсчет количества Tags
            foreach (var tag in advertisement.Tags)
            {
                if (tag.Count > 0)
                {
                    tag.Count -= 1;
                    await _tagRepository.Save(tag, cancellationToken);
                }
            }

            await _advertisementRepository.Save(advertisement, cancellationToken);
        }
    }
}