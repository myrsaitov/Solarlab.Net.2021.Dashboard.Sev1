using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.GetPaged;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;
using Sev1.Advertisements.Contracts.Exceptions.GetPaged;

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
        public async Task<CategoryGetPagedResponse> GetPaged(
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
                return new CategoryGetPagedResponse
                {
                    Items = Array.Empty<CategoryGetResponse>(),
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
            return new CategoryGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<CategoryGetResponse>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}