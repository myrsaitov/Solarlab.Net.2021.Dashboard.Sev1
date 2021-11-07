using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Interfaces.Identity
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
        /// если да, то возвращает его роль и Id
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<ValidateTokenResponse> ValidateToken(
            CancellationToken cancellationToken);

        /// <summary>
        /// Проверка роли (по параметру РОЛЬ)
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="role">Предполагаемая роль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<bool> IsInRole(
            string userId, 
            string role, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="request">Данные с формы</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<CreateUser.Response> CreateUser(
            CreateUser.Request request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Логин (создание токена)
        /// </summary>
        /// <param name="request">E-mail и пароль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<CreateToken.Response> CreateToken(
            CreateToken.Request request, 
            CancellationToken cancellationToken);



        /// <summary>
        /// Возвращает роль пользователя по Id
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetUserRolesById(
            string userId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает роль аутентифицированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetCurrentUserRoles(
            CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет пользователя в указанную роль 
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task AddToRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Убирает пользователя из указанной роли
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task RemoveFromRole(
            string userId,
            string role,
            CancellationToken cancellationToken = default);

        /*Task<bool> ConfirmEmail(
            string userId, 
            string token, 
            CancellationToken cancellationToken = default);*/
    }
}
