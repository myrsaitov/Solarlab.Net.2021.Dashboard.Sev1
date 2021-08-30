using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Common;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts.Exceptions;
using Sev1.Advertisements.Application.Services.Advertisement.Interfaces;
using Sev1.Advertisements.Domain.Shared.Exceptions;

namespace Sev1.Advertisements.Application.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Delete(
            Delete.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var advertisement = await _advertisementRepository.FindByIdWithUserAndTagsInclude(
                request.Id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(request.Id);
            }

            var userId = await _identityService.GetCurrentUserId(cancellationToken);

            var isAdmin = await _identityService.IsInRole(
                userId,
                RoleConstants.AdminRole,
                cancellationToken);

            if (!isAdmin && advertisement.OwnerId != userId)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
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