using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using Sev1.UserFiles.AppServices.Services.Validators.GetPaged;
using Sev1.UserFiles.AppServices.Exceptions.UserFile;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Implementations
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Получить пагинированные объявления
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileGetPagedResponse> GetPaged(
            UserFileGetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFileGetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new GetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Вычислить смещение (skip)
            var offset = request.Page * request.PageSize;
            
            // Подсчет общего количества объявлений
            var total = await _userFileRepository
                .CountWithOutDeleted(cancellationToken);

            // Если объявления не найдены, то возвращаем "пустой" ответ 
            if (total == 0)
            {
                return new UserFileGetPagedResponse
                {
                    Items = Array.Empty<UserFileGetResponse>(),
                    Total = 0,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            // Если объявления найдены
            var entities = await _userFileRepository
                .GetPagedWithTagsAndCategoryInclude(
                    offset,
                    request.PageSize,
                    cancellationToken);

            // Создание обёртки (wrapper)
            return new UserFileGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<UserFileGetResponse>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}