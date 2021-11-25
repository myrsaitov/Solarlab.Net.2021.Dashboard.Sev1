using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.AppServices.Services.Region.Validators;
using Sev1.Advertisements.Contracts.Contracts.Region.Responses;
using Sev1.Advertisements.AppServices.Services.Region.Interfaces;
using Sev1.Advertisements.AppServices.Services.Region.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Region.Implementations
{
    public sealed partial class RegionServiceV1 : IRegionService
    {
        /// <summary>
        /// Возвращает пагинированные регионы
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<RegionGetPagedResponse> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new RegionGetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new RegionGetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var total = await _regionRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new RegionGetPagedResponse
                {
                    Items = Array.Empty<RegionGetResponse>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _regionRepository.GetPaged(
                1,
                request.PageSize,
                cancellationToken);


            return new RegionGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<RegionGetResponse>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }

        /// <summary>
        /// Возвращает пагинированные регионы
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<RegionGetPagedResponseV2> GetPagedV2(
            GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new RegionGetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new RegionGetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var total = await _regionRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new RegionGetPagedResponseV2
                {
                    Items = Array.Empty<RegionGetResponseV2>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _regionRepository.GetPaged(
                request.Page,
                request.PageSize,
                cancellationToken);


            return new RegionGetPagedResponseV2
            {
                Items = entities.Select(entity => _mapper.Map<RegionGetResponseV2>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}