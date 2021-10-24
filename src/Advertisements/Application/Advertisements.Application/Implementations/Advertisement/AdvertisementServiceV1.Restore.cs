using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Restore(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Получаем Id текущего пользователя
            var currentUserId = await _userRepository.GetCurrentUserId(accessToken, cancellationToken);

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

            // Пользователь может восстанавливать только свои собственные объявления
            if (advertisement.OwnerId != currentUserId)
            {
                // Но только если он не модератор или админ
                if (!await _userRepository.IsAdmin(accessToken, cancellationToken))
                {
                    throw new NoRightsException("Не хватает прав восстановить объявление!");
                }
            }

            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}