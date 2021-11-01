using Advertisements.Contracts.Contracts.User;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Contracts.ApiClients.User
{
    public interface IUserApiClient
    {
        /// <summary>
        /// Проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> ValidateToken(
            string accessToken,
            CancellationToken cancellationToken);
    }
}