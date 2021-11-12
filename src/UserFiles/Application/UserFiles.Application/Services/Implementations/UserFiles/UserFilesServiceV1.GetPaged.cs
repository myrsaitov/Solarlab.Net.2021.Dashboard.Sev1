using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Contracts.Contracts.UserFile;
using Sev1.UserFiles.Application.Services.Interfaces.UserFile;
using Sev1.UserFiles.Contracts.Contracts.GetPaged;
using System.Linq.Expressions;
using Sev1.UserFiles.Application.Services.Validators.GetPaged;
using Sev1.UserFiles.Application.Exceptions.UserFile;

namespace Sev1.UserFiles.Application.Services.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Получить пагинированные объявления
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<GetPagedUserFileResponse> GetPaged(
            GetPagedUserFileRequest request,
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
            Expression<Func<Domain.UserFile, bool>> predicate = a => true;

            // Если нет параметров поиска, выводим без какой-либо фильтрации
            if ((string.IsNullOrWhiteSpace(request.SearchStr))
                && (string.IsNullOrWhiteSpace(request.UserId))
                && (request.CategoryId is null)
                && (string.IsNullOrWhiteSpace(request.Tag)))
            {
                predicate = a => true; // Фильтрация отсутствует
            }


            // Подсчет общего количества объявлений
            var total = await _userFileRepository.CountWithOutDeleted(
                predicate,
                cancellationToken);

            // Если объявления не найдены, то возвращаем "пустой" ответ 
            if (total == 0)
            {
                return new GetPagedUserFileResponse
                {
                    Items = Array.Empty<UserFilePagedDto>(),
                    Total = 0,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            // Если объявления найдены
            var entities = await _userFileRepository.GetPagedWithTagsAndCategoryInclude(
                predicate,
                offset,
                request.PageSize,
                cancellationToken);

            // Создание обёртки (wrapper)
            return new GetPagedUserFileResponse
            {
                Items = entities.Select(entity => _mapper.Map<UserFilePagedDto>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}