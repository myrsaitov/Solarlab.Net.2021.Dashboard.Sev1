using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Services.Interfaces.User
{
    public interface IUserService
    {
        /// <summary>
        /// Регистрирует новго пользователя
        /// </summary>
        /// <param name="registerRequest">DTO запроса</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> Register(
            UserRegisterRequest registerRequest, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные пользователя
        /// </summary>
        /// <param name="request">DTO запроса</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Update(
            UserUpdateRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Domain.User> Get(
            string userId,
            CancellationToken cancellationToken);
    }
}