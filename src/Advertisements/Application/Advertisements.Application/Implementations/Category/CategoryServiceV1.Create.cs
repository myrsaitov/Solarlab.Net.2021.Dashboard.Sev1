using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using System.Collections.Generic;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<int> Create(
            CategoryCreateDto request, 
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }



            var category = _mapper.Map<Domain.Category>(request);
            category.IsDeleted = false;
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            var parentCategoryIdNulable = request.ParentCategoryId;
            if (parentCategoryIdNulable != null)
            {
                int parentCategoryId = (int)parentCategoryIdNulable;
                var parentCategory = await _categoryRepository.FindById(parentCategoryId, cancellationToken);
                if (parentCategory != null)
                {
                    if (parentCategory.ChildCategories != null)
                    {
                        parentCategory.ChildCategories.Add(category);
                    }
                    else
                    {
                        parentCategory.ChildCategories = new List<Domain.Category>()
                        {
                            category
                        };
                    }
                    await _categoryRepository.Save(parentCategory, cancellationToken);
                    
                    category.ParentCategory = parentCategory;
                }
                await _categoryRepository.Save(category, cancellationToken);
            }

            return category.Id;
        }
    }
}