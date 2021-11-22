using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Services.Category.Interfaces;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;
using Sev1.Advertisements.AppServices.Services.Category.Exceptions;
using Sev1.Advertisements.AppServices.Services.Category.Validators;

namespace Sev1.Advertisements.AppServices.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Возвращает категорию из базы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<CategoryGetResponse> GetById(
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

            // Достаем категорию из базы по Id
            var category = await _categoryRepository.FindByIdWithParentAndChilds(
                id, 
                cancellationToken);

            // Если ее нет в базе, то выход
            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            category.ChildCategories = await _categoryRepository.GetAllChilds(
                category.Id,
                cancellationToken);

            // Возвращаем dto категории
            return _mapper.Map<CategoryGetResponse>(category);
        }
    }
}