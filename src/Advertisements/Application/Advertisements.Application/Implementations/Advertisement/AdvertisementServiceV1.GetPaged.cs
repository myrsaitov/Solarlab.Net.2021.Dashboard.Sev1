using Mapster;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Contracts;
using System.Linq.Expressions;
using Sev1.Advertisements.Application.Validators.GetPaged;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task<Paged.Response<AdvertisementPagedDto>> GetPaged(
            Paged.Request request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new GetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new GetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var offset = request.Page * request.PageSize;

            var total = await _advertisementRepository.CountWithOutDeleted(cancellationToken);

            if (total == 0)
            {
                return new Paged.Response<AdvertisementPagedDto>
                {
                    Items = Array.Empty<AdvertisementPagedDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _advertisementRepository.GetPagedWithTagsAndOwnerAndCategoryInclude(
                offset, 
                request.PageSize, 
                cancellationToken
            );

            return new Paged.Response<AdvertisementPagedDto>
            {
                Items = entities.Select(entity => _mapper.Map<AdvertisementPagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
        public async Task<Paged.Response<AdvertisementPagedDto>> GetPaged(
            Expression<Func<Domain.Advertisement, bool>> predicate,
            Paged.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var total = await _advertisementRepository.CountWithOutDeleted(
                predicate,
                cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new Paged.Response<AdvertisementPagedDto>
                {
                    Items = Array.Empty<AdvertisementPagedDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _advertisementRepository.GetPagedWithTagsAndOwnerAndCategoryInclude(
                predicate,
                offset,
                request.PageSize,
                cancellationToken
            );

            return new Paged.Response<AdvertisementPagedDto>
            {
                Items = entities.Select(entity => entity.Adapt<AdvertisementPagedDto>()),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}