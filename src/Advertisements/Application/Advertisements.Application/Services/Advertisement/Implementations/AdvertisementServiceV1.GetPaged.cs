using Mapster;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Services.Advertisement.Interfaces;
using Sev1.Advertisements.Application.Contracts;
using System.Linq.Expressions;

namespace Sev1.Advertisements.Application.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task<Paged.Response<GetPaged.Response>> GetPaged(
            Paged.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var offset = request.Page * request.PageSize;

            var total = await _advertisementRepository.CountWithOutDeleted(cancellationToken);

            if (total == 0)
            {
                return new Paged.Response<GetPaged.Response>
                {
                    Items = Array.Empty<GetPaged.Response>(),
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

            return new Paged.Response<GetPaged.Response>
            {
                Items = entities.Select(entity => _mapper.Map<GetPaged.Response>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
        public async Task<Paged.Response<GetPaged.Response>> GetPaged(
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
                return new Paged.Response<GetPaged.Response>
                {
                    Items = Array.Empty<GetPaged.Response>(),
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

            return new Paged.Response<GetPaged.Response>
            {
                Items = entities.Select(entity => entity.Adapt<GetPaged.Response>()),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}