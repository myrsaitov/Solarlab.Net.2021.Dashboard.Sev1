﻿using Sev1.Accounts.AppServices.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using System.Collections.Generic;
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

        /// <summary>
        /// Возвращает DTO авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserResponse> GetCurrentUser(
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает пользователей по массиву идентификаторов
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Dictionary<string, UserResponse>> GetUsersByListId(
            List<string> UserList,
            CancellationToken cancellationToken);
    }
}