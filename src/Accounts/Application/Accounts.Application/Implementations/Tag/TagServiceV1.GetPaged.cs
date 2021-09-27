using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Tag;
using System;
using System.Linq;
using Sev1.Accounts.Application.Contracts.GetPaged;
using Sev1.Accounts.Application.Interfaces.Tag;
using Sev1.Accounts.Application.Validators.GetPaged;
using Sev1.Accounts.Application.Exceptions.Advertisement;

namespace Sev1.Accounts.Application.Implementations.Tag
{
    public sealed partial class TagServiceV1 : ITagService
    {
        public async Task<GetPagedResponse<TagPagedDto>> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new GetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new GetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var total = await _tagRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new GetPagedResponse<TagPagedDto>
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


            return new GetPagedResponse<TagPagedDto>
            {
                Items = entities.Select(entity => _mapper.Map<TagPagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}