using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Contracts.Advertisement;
using Sev1.Advertisements.AppServices.Services.Interfaces.Advertisement;
using System.Linq.Expressions;
using Sev1.Advertisements.AppServices.Services.Validators.GetPaged;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Responses;
using Sev1.Advertisements.AppServices.Exceptions.GetPaged;

namespace Sev1.Advertisements.AppServices.Services.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Получить пагинированные объявления
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<AdvertisementGetPagedResponse> GetPaged(
            AdvertisementGetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AdvertisementGetPagedRequestValidator();
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
                && (string.IsNullOrWhiteSpace(request.OwnerId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                predicate = a => true; // Фильтрация отсутствует
            }
            // Если пришли параметры поиска
            else if ((!string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.OwnerId))
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
                && (!string.IsNullOrWhiteSpace(request.OwnerId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по UserId
                predicate =
                    a => a.OwnerId == request.OwnerId;
            }
            else if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.OwnerId))
                && (!(request.CategoryId is null))
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по CategoryId
                predicate =
                    a => a.CategoryId == request.CategoryId;
            }
            else if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.OwnerId))
                && ((request.CategoryId is null))
                && (!string.IsNullOrWhiteSpace(request.Tag)))
            {
                // Поиск по Tag
                predicate =
                    a => a.Tags.Any(t => t.Body == request.Tag);
            }

            // Подсчет общего количества объявлений
            var total = await _advertisementRepository.CountActive(
                predicate,
                cancellationToken);

            // Если объявления не найдены, то возвращаем "пустой" ответ 
            if (total == 0)
            {
                return new AdvertisementGetPagedResponse
                {
                    Items = Array.Empty<AdvertisementGetPagedDto>(),
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
            return new AdvertisementGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<AdvertisementGetPagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}