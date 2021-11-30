using Sev1.Accounts.AppServices.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.AppServices.Services.User.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Регистрирует новго пользователя
        /// </summary>
        /// <param name="registerRequest">DTO запроса</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserIdResponse> Register(
            UserRegisterRequest registerRequest, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserLoginResponse> Login(
            UserLoginRequest request,
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
        Task<UserGetResponse> Get(
            string userId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает DTO авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserGetResponse> GetCurrentUser(
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает пагинированных пользователей
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserGetPagedResponse> GetPaged(
            UserGetPagedRequest request,
            CancellationToken cancellationToken);
    }
}