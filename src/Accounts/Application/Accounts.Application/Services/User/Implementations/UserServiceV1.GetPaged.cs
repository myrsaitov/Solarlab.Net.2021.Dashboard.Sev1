using Sev1.Accounts.AppServices.Services.User.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.AppServices.Services.User.Validators;
using System;
using System.Linq;
using Sev1.Advertisements.AppServices.Services.Region.Exceptions;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        /// <summary>
        /// Возвращает пагинированных пользователей
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserGetPagedResponse> GetPaged(
            UserGetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserGetPagedRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new UserGetPagedRequestNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var total = await _userRepository.Count(cancellationToken);

            var offset = request.Page * request.PageSize;

            if (total == 0)
            {
                return new UserGetPagedResponse
                {
                    Items = Array.Empty<UserGetResponse>(),
                    Total = total,
                    Offset = offset,
                    Limit = request.PageSize
                };
            }

            var entities = await _userRepository.GetPaged(
                request.Page,
                request.PageSize,
                cancellationToken);

            return new UserGetPagedResponse
            {
                Items = entities.Select(entity => _mapper.Map<UserGetResponse>(entity)),
                Total = total,
                Offset = offset,
                Limit = request.PageSize
            };
        }
    }
}