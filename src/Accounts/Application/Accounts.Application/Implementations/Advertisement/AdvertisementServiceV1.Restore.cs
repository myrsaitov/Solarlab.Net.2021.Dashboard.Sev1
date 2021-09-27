using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Advertisement;
using Sev1.Accounts.Application.Interfaces.Advertisement;
using Sev1.Accounts.Application.Validators.Advertisement;

namespace Sev1.Accounts.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Restore(
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