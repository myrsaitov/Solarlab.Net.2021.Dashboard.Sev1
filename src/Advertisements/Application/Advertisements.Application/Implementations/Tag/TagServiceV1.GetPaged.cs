using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Tag;
using System;
using System.Linq;
using Sev1.Advertisements.Application.Contracts;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Tag
{
    public sealed partial class TagServiceV1 : ITagService
    {
        public async Task<Paged.Response<TagPagedDto>> GetPaged(
            Paged.Request request, 
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var total = await _tagRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new Paged.Response<TagPagedDto>
                {
                    Items = Array.Empty<TagPagedDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _tagRepository.GetPaged(
                offset,
                request.PageSize,
                cancellationToken);


            return new Paged.Response<TagPagedDto>
            {
                Items = entities.Select(entity => _mapper.Map<TagPagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}