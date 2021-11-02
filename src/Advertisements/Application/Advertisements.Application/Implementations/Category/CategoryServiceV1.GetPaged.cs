using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Contracts.GetPaged;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.GetPaged;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Пагинация категорий
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<GetPagedResponse<CategoryDto>> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new GetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new GetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Получить количество категорий
            var total = await _categoryRepository.Count(cancellationToken);

            // Смещение
            var offset = request.Page * request.PageSize;

            // Если ничего не нашлось
            if (total == 0)
            {
                return new GetPagedResponse<CategoryDto>
                {
                    Items = Array.Empty<CategoryDto>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            // Если есть хоть одно
            var entities = await _categoryRepository.GetPaged(
                offset, 
                request.PageSize, 
                cancellationToken
            );

            // Поместить массив объектов в обёртку
            return new GetPagedResponse<CategoryDto>
            {
                Items = entities.Select(entity => _mapper.Map<CategoryDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}