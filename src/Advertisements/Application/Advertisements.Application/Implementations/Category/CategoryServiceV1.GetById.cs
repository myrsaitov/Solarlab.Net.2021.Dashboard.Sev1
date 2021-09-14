using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<CategoryDto> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            /*if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }*/

            var category = await _categoryRepository.FindByIdWithParentAndChilds(
                id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}