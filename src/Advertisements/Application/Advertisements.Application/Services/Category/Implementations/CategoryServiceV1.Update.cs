using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Category.Interfaces;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.AppServices.Exceptions.Category;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.AppServices.Services.Category.Validators;

namespace Sev1.Advertisements.AppServices.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Редактировать категорию (только админ или модератор)
        /// </summary>
        /// <param name="request">DTO</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<int?> Update(
            CategoryUpdateRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryUpdateRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new CategoryUpdateRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var category = await _categoryRepository.FindById(
                request.Id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(request.Id);
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

            category = _mapper.Map<Domain.Category>(request);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return category.Id;
        }
    }
}