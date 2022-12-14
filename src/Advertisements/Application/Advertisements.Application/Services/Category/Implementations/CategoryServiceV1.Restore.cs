using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Category.Interfaces;
using Sev1.Advertisements.AppServices.Services.Category.Exceptions;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.AppServices.Services.Category.Validators;

namespace Sev1.Advertisements.AppServices.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Восстановить удаленную категорию по идентификатору
        /// (только админ или модератор)
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Restore(
            int? id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CategoryIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new CategoryIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Достаем из базы категорию по Id
            var category = await _categoryRepository.FindById(
                id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            // Пользователь может восстановить категорию:
            //  - если он администратор;
            //  - если он модератор;
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            if (!(isAdministrator || isModerator))
            {
                throw new NoRightsException("Восстановить категорию может только модератор или админ!");
            }

            // Снять пометку об удалении
            category.IsDeleted = false;

            // Обновить время редактирования
            category.UpdatedAt = DateTime.UtcNow;

            // Сохранить изменения в базу
            await _categoryRepository.Save(
                category, 
                cancellationToken);
        }
    }
}