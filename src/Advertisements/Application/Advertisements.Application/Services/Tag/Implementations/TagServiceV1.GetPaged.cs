using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Tag.Interfaces;
using Sev1.Advertisements.Application.Services.Tag.Contracts;
using System;
using System.Linq;
using Sev1.Advertisements.Application.Services.Contracts;

namespace Sev1.Advertisements.Application.Services.Tag.Implementations
{
    public sealed partial class TagServiceV1 : ITagService
    {
        public async Task<Paged.Response<GetById.Response>> GetPaged(
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
                return new Paged.Response<GetById.Response>
                {
                    Items = Array.Empty<GetById.Response>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _tagRepository.GetPaged(
                offset,
                request.PageSize,
                cancellationToken);


            return new Paged.Response<GetById.Response>
            {
                Items = entities.Select(entity => _mapper.Map<GetById.Response>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}