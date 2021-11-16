using System.Collections.Generic;

namespace Sev1.Accounts.Contracts.Contracts.User.Responses
{
    /// <summary>
    /// Ответ на запрос авторизации
    /// </summary>
    public class UserLoginResponse
    {
        /// <summary>
        /// JWT-токен
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Список ролей
        /// </summary>
        public IEnumerable<string> Roles { get; set; }
    }
}