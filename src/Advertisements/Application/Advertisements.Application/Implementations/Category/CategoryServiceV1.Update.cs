using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Contracts.Contracts.Category;
using Sev1.Advertisements.Contracts.Exception;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Редактировать категорию (только админ или модератор)
        /// </summary>
        /// <param name="model">DTO</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
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

            // Пользователь может обновить категорию:
            //  - если он администратор;
            //  - если он модератор;
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator"); ;
            if (!(isAdministrator || isModerator))
            {
                throw new NoRightsException("Обновить категорию может только модератор или админ!");
            }

            category = _mapper.Map<Domain.Category>(model);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return category.Id;
        }
    }
}