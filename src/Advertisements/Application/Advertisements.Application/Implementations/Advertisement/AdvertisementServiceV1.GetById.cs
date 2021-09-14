using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task<AdvertisementDto> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            /*f (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }*/

            var advertisement = await _advertisementRepository.FindByIdWithUserAndCategoryAndTags(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            var response = _mapper.Map<AdvertisementDto>(advertisement);

            return response;
        }
    }
}