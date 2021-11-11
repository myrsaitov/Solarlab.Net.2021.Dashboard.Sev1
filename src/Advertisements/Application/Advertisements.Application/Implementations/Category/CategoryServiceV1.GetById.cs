using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Contracts.Contracts.Category;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;

namespace Sev1.Advertisements.Application.Implementations.Category
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

            // Достаем категорию из базы по Id
            var category = await _categoryRepository.FindByIdWithParentAndChilds(
                id, 
                cancellationToken);

            // Если ее нет в базе, то выход
            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            // Возвращаем dto категории
            return _mapper.Map<CategoryGetResponse>(category);
        }
    }
}