using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sev1.Advertisements.Application.Services.Interfaces.Category;
using System.Linq;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Exceptions.Domain;
using Sev1.Advertisements.Application.Services.Validators.Category;

namespace Sev1.Advertisements.Application.Services.Implementations.Categoryt
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Создать категорию (только админ или модератор)
        /// </summary>
        /// <param name="request">DTO</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<int?> Create(
            CategoryCreateRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryCreateRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new CategoryCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Пользователь может создать категорию:
            //  - если он администратор;
            //  - если он модератор;
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            if (!(isAdministrator || isModerator))
            {
                throw new NoRightsException("Создать категорию может только модератор или админ!");
            }

            // Создаем категорию
            var category = _mapper.Map<Domain.Category>(request);
            category.IsDeleted = false;
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            // Редактируем родительскую категорию, если есть
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