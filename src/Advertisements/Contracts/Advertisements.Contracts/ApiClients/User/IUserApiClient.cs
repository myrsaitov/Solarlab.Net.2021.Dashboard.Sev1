using Advertisements.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Contracts.ApiClients.User
{
    public interface IUserApiClient
    {
        /// <summary>
        /// Возвращает userId текущего зарегистрированного пользователя
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> GetCurrentUserId(
            string accessToken,
            CancellationToken cancellationToken);

        /// <summary>
        /// Проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetAutorizedStatusResponse> GetAutorizedStatus(
            string accessToken,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает проверку на роль администратора
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<bool> IsAdmin(
            string accessToken,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает проверку на роль модератора
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<bool> IsModerator(
            string accessToken,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает роль авторизированного пользователя
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> GetCurrentUserRole(
            string accessToken,
            CancellationToken cancellationToken);
    }
}