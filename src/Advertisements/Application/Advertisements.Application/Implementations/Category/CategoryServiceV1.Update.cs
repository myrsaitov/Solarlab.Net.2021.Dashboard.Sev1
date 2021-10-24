using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<int> Update(
            string accessToken,
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Получаем Id текущего пользователя
            var currentUserId = await _userRepository.GetCurrentUserId(accessToken, cancellationToken);

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

            // Тут только модератор и админ
            if (!await _userRepository.IsAdmin(accessToken, cancellationToken))
            {
                throw new NoRightsException("Только модератор или админ!");
            }

            category = _mapper.Map<Domain.Category>(model);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return category.Id;
        }
    }
}