using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Interfaces.Advertisement;
using Sev1.Advertisements.AppServices.Services.Validators.Advertisement;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using Sev1.Advertisements.AppServices.Exceptions.Advertisement;

namespace Sev1.Advertisements.AppServices.Services.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementGetResponse> GetById(
            int? id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new AdvertisementIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Достаем объявление из базы по идентификатору
            var advertisement = await _advertisementRepository.FindByIdWithCategoriesAndTags(
                id,
                cancellationToken);

            // Если объявление с таким идентификатором не существует, то исключение
            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Маппим сущность на DTO и возвращаем
            return _mapper.Map<AdvertisementGetResponse>(advertisement);
        }
    }
}