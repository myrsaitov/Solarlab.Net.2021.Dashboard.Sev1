using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Interfaces.User
{
    public interface IUserService
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
    }
}