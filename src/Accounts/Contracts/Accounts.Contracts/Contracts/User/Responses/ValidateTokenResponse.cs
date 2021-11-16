using System.Collections.Generic;

namespace Sev1.Accounts.Contracts.Contracts.User.Responses
{
    /// <summary>
    /// Ответ на запрос при валидации токена
    /// </summary>
    public class ValidateTokenResponse
    {
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