using Sev1.Accounts.Contracts.Contracts.User.Responses;
using System.Threading.Tasks;

namespace Sev1.Accounts.Contracts.ApiClients.User
{
    public interface IUserValidateApiClient
    {
        /// <summary>
        /// API-client проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="authorizationHeader">JWT Token, который пришел с запросом</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> UserValidate(
            string authorizationHeader);
    }
}