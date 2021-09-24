using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.DomainUser;
using Sev1.Accounts.Application.Contracts.GetPaged;
using Sev1.Accounts.Application.Interfaces.DomainUser;
using Sev1.Accounts.Application.Validators.GetPaged;
using Sev1.Accounts.Application.Exceptions.DomainUser;

namespace Sev1.Accounts.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        public async Task<GetPagedResponse<DomainUserDto>> GetPaged(
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

            var total = await _domainUserRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new GetPagedResponse<DomainUserDto>
                {
                    Items = Array.Empty<DomainUserDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _domainUserRepository.GetPaged(
                offset, 
                request.PageSize, 
                cancellationToken
            );

            return new GetPagedResponse<DomainUserDto>
            {
                Items = entities.Select(entity => _mapper.Map<DomainUserDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}