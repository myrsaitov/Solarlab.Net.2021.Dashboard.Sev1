using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Contracts.GetPaged;
using System.Linq.Expressions;
using Sev1.Advertisements.Application.Validators.GetPaged;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
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
            
            Expression<Func<Domain.Advertisement, bool>> predicate = default;
            // Если нет параметров поиска, выводим без какой-либо фильтрации
            if ((request.SearchStr is null)
                && (request.UserName is null)
                && (request.CategoryId is null)
                 && (request.Tag is null))
            {
                predicate = default;
            }
            // Если пришли параметры поиска
            else if ((request.SearchStr is not null)
                && (request.UserName is null)
                && (request.CategoryId is null)
                && (request.Tag is null))
            {
                // Общий поиск
                predicate =
                    o => o.Body.ToLower().Contains(request.SearchStr.ToLower())  // В теле объявления
                    || o.Title.ToLower().Contains(request.SearchStr.ToLower())  // В названии объявления
                    || o.Category.Name.ToLower().Contains(request.SearchStr.ToLower()) // По имени категории
                    || o.Tags.Select(a => a.Body).ToArray().Contains(request.SearchStr.ToLower()); // По  tag
            }
            else if ((request.SearchStr is null)
                && (request.UserName is null)
                && (request.CategoryId is not null)
                && (request.Tag is null))
            {
                // Поиск по CategoryId
                predicate =
                    a => a.CategoryId == request.CategoryId;
            }
            else if ((request.SearchStr is null)
                && (request.UserName is null)
                && (request.CategoryId is null)
                && (request.Tag is not null))
            {
                // Поиск по Tag
                predicate =
                    a => a.Tags.Any(t => t.Body == request.Tag);
            }

            // Подсчет общего количества объявлений
            int total = default;
            if (predicate == default)
            {
                // Если параметры поиска не заданы
                total = await _advertisementRepository.CountWithOutDeleted(cancellationToken);
            }
            else
            {
                // Если параметры поиска заданы
                total = await _advertisementRepository.CountWithOutDeleted(
                    predicate,
                    cancellationToken);
            }

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
            if (predicate == default)
            {
                // Вернуть объявления без фильтра
                var entities = await _advertisementRepository.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    offset,
                    request.PageSize,
                    cancellationToken);

                return new GetPagedAdvertisementResponse
                {
                    Items = entities.Select(entity => _mapper.Map<AdvertisementPagedDto>(entity)),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }
            else
            {
                // Вернуть объявления по фильтру
                var entities = await _advertisementRepository.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    predicate,
                    offset,
                    request.PageSize,
                    cancellationToken);

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
}