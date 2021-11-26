using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using Sev1.Advertisements.AppServices.Services.Tag.Interfaces;
using Sev1.Advertisements.Contracts.Contracts.Tag.Responses;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.AppServices.Services.Tag.Validators;
using Sev1.Advertisements.AppServices.Services.Tag.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Tag.Implementations
{
    public sealed partial class TagServiceV1 : ITagService
    {
        /// <summary>
        /// Возвращает пагинированные тэги
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<TagGetPagedResponse> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new TagGetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new TagGetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var total = await _tagRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new TagGetPagedResponse
                {
                    Items = Array.Empty<TagGetResponse>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _tagRepository.GetPagedWhereAdvertismentsNotNull(
                offset,
                request.PageSize,
                cancellationToken);


            return new TagGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<TagGetResponse>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}