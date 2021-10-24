using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Validators.Advertisement;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Получить объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementDto> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new AdvertisementIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

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