using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Contracts;
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
        Task<string> GetCurrentUserId(
            CancellationToken cancellationToken);

        /// <summary>
        /// Проверка, аутентифицирован ли пользователь,
        /// если да, то возвращает его роль и Id
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetAutorizedStatusResponse> GetAutorizedStatus(
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
        /// <param name="request">Логин и пароль</param>
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
        Task<string> GetUserRoleById(
            string userId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает роль аутентифицированного пользователя
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> GetCurrentUserRole(
            CancellationToken cancellationToken);

        /// <summary>
        /// Изменить роль пользователя на юзер
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> SetUserRoleUser(
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Изменить роль пользователя на модератор
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> SetUserRoleModerator(
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Изменить роль пользователя на админ
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<string> SetUserRoleAdmin(
            string userId,
            CancellationToken cancellationToken = default);

        /*Task<bool> ConfirmEmail(
            string userId, 
            string token, 
            CancellationToken cancellationToken = default);*/
    }
}
