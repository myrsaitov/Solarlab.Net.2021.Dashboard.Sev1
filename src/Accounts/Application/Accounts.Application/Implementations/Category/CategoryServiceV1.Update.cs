using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Category;
using Sev1.Accounts.Application.Exceptions.Advertisement;
using Sev1.Accounts.Application.Exceptions.Category;
using Sev1.Accounts.Application.Interfaces.Category;
using Sev1.Accounts.Application.Validators.Advertisement;

namespace Sev1.Accounts.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<int> Update(
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryUpdateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new CategoryUpdateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var category = await _categoryRepository.FindById(
                model.Id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(model.Id);
            }


            category = _mapper.Map<Domain.Category>(model);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return category.Id;
        }
    }
}