using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.Identity.Responses;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.AppServices.Services.Identity.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Возвращает Id аутентифицированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        string GetCurrentUserId(
            CancellationToken cancellationToken);

        /// <summary>
        /// Проверка, аутентифицирован ли пользователь,
        /// если да, то возвращает его роль и идентификатор
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> ValidateToken(
            CancellationToken cancellationToken);

        /// <summary>
        /// Проверяет, имеет ли пользователь указанную роль
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="role">Проверяемая роль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<bool> IsInRole(
            string userId, 
            string role, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Зарегистрировать пользователя в Identity
        /// </summary>
        /// <param name="request">DTO с данными пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IdentityUserCreateResponse> CreateUser(
            IdentityUserCreateRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="request">E-mail и пароль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IdentityUserCreateTokenResponse> CreateToken(
            UserLoginRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает роли пользователя по Id
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetUserRolesById(
            string userId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает роли авторизированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetCurrentUserRoles(
            CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет пользователя в указанную роль 
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task AddToRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Убирает пользователя из указанной роли
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task RemoveFromRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default);
    }
}