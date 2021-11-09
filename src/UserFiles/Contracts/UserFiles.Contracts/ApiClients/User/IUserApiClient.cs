﻿using Sev1.UserFiles.Contracts.Contracts.User;
using System.Threading.Tasks;

namespace Sev1.UserFiles.Contracts.ApiClients.User
{
    public interface IUserApiClient
    {
        /// <summary>
        /// API-client проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> ValidateToken(
            string accessToken);
    }
}