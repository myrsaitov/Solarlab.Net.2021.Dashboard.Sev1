using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Category;
using Sev1.Accounts.Application.Contracts.GetPaged;
using Sev1.Accounts.Application.Interfaces.Category;
using Sev1.Accounts.Application.Validators.GetPaged;
using Sev1.Accounts.Application.Exceptions.Account;

namespace Sev1.Accounts.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<GetPagedResponse<CategoryDto>> GetPaged(
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

            var total = await _categoryRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new GetPagedResponse<CategoryDto>
                {
                    Items = Array.Empty<CategoryDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _categoryRepository.GetPaged(
                offset, 
                request.PageSize, 
                cancellationToken
            );

            return new GetPagedResponse<CategoryDto>
            {
                Items = entities.Select(entity => _mapper.Map<CategoryDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}