using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Contracts;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<Paged.Response<CategoryDto>> GetPaged(
            Paged.Request request, 
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var total = await _categoryRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new Paged.Response<CategoryDto>
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

            return new Paged.Response<CategoryDto>
            {
                Items = entities.Select(entity => _mapper.Map<CategoryDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}