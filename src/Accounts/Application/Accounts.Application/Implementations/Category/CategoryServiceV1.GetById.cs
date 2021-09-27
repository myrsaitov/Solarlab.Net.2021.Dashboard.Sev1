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
        public async Task<CategoryDto> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new CategoryIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

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