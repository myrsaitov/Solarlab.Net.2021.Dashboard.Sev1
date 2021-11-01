using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Восстановить удаленную категорию (только админ или модератор)
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Restore(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Проверяем, авторизирован ли пользователь, получаем его Id и Role
            var autorizedStatus = await _userApiClient.ValidateToken(
                accessToken,
                cancellationToken);
            if (autorizedStatus is null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }
            
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
            var isAdmin = (autorizedStatus.Role == "admin");
            var isModerator = (autorizedStatus.Role == "moderator");
            if (!(isAdmin || isModerator))
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