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
        public async Task<int> Update(
            CategoryUpdateDto request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var category = await _categoryRepository.FindById(
                request.Id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(request.Id);
            }


            category = _mapper.Map<Domain.Category>(request);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return category.Id;
        }
    }
}