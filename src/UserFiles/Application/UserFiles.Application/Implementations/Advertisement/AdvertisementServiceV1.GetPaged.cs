using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Contracts.Advertisement;
using Sev1.UserFiles.Application.Interfaces.Advertisement;
using Sev1.UserFiles.Application.Contracts.GetPaged;
using System.Linq.Expressions;
using Sev1.UserFiles.Application.Validators.GetPaged;
using Sev1.UserFiles.Application.Exceptions.Advertisement;

namespace Sev1.UserFiles.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Получить пагинированные объявления
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<GetPagedAdvertisementResponse> GetPaged(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new GetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new GetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Вычислить смещение (skip)
            var offset = request.Page * request.PageSize;
            
            // Параметр поиска в базе
            Expression<Func<Domain.Advertisement, bool>> predicate = a => true;

            // Если нет параметров поиска, выводим без какой-либо фильтрации
            if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.UserId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                predicate = a => true; // Фильтрация отсутствует
            }
            // Если пришли параметры поиска
            else if ((!string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.UserId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Общий поиск
                predicate =
                    o => o.Body.ToLower().Contains(request.SearchStr.ToLower())  // В теле объявления
                    || o.Title.ToLower().Contains(request.SearchStr.ToLower())  // В названии объявления
                    || o.Category.Name.ToLower().Contains(request.SearchStr.ToLower()) // По имени категории
                    || o.Tags.Select(a => a.Body).ToArray().Contains(request.SearchStr.ToLower()); // По tag
            }
            else if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (!string.IsNullOrWhiteSpace(request.UserId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по UserId
                predicate =
                    a => a.OwnerId == request.UserId;
            }
            else if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.UserId))
                && (!(request.CategoryId is null))
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по CategoryId
                predicate =
                    a => a.CategoryId == request.CategoryId;
            }
            else if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.UserId))
                && ((request.CategoryId is null))
                && (!string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по Tag
                predicate =
                    a => a.Tags.Any(t => t.Body == request.Tag);
            }

            // Подсчет общего количества объявлений
            var total = await _advertisementRepository.CountWithOutDeleted(
                predicate,
                cancellationToken);

            // Если объявления не найдены, то возвращаем "пустой" ответ 
            if (total == 0)
            {
                return new GetPagedAdvertisementResponse
                {
                    Items = Array.Empty<AdvertisementPagedDto>(),
                    Total = 0,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            // Если объявления найдены
            var entities = await _advertisementRepository.GetPagedWithTagsAndCategoryInclude(
                predicate,
                offset,
                request.PageSize,
                cancellationToken);

            // Создание обёртки (wrapper)
            return new GetPagedAdvertisementResponse
            {
                Items = entities.Select(entity => _mapper.Map<AdvertisementPagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}