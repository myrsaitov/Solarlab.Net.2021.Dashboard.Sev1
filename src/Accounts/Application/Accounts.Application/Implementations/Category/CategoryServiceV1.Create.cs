using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Category;
using System.Collections.Generic;
using Sev1.Accounts.Application.Interfaces.Category;
using Sev1.Accounts.Application.Validators.Advertisement;
using Sev1.Accounts.Application.Exceptions.Advertisement;
using System.Linq;

namespace Sev1.Accounts.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<int> Create(
            CategoryCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new CategoryCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var category = _mapper.Map<Domain.Category>(model);
            category.IsDeleted = false;
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            var parentCategoryIdNulable = model.ParentCategoryId;
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