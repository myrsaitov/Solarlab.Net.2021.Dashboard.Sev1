using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Category;
using Sev1.Accounts.Application.Exceptions;
using Sev1.Accounts.Application.Exceptions.Account;
using Sev1.Accounts.Application.Exceptions.Category;
using Sev1.Accounts.Application.Interfaces.Category;
using Sev1.Accounts.Application.Validators.Account;
using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task Restore(
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

            var category = await _categoryRepository.FindById(
                id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(
                category, 
                cancellationToken);
        }
    }
}