using Sev1.Accounts.Contracts.Contracts.User.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sev1.Accounts.Contracts.ApiClients.User
{
    public interface IUserValidateApiClient
    {
        /// <summary>
        /// API-client проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> UserValidate(
            string accessToken);


        /// <summary>
        /// API-client получить данные пользователей по их идентификаторам.
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <returns></returns>
        Task<Dictionary<string, UserResponse>> GetUsersByListId(List<string> userList);
    }
}