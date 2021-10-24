using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Repositories.User
{
    public interface IUserRepository
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
        /// Возвращает проверку на роль администратора
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<bool> IsAdmin(
            string accessToken,
            CancellationToken cancellationToken);
    }
}