using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Restore(
            int id,
            CancellationToken cancellationToken)
        {
            /*if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }*/

            var advertisement = await _advertisementRepository.FindByIdWithUserInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }



            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}