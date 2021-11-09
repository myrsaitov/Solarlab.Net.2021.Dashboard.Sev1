using System.Collections.Generic;

namespace Sev1.Accounts.Contracts
{
    /// <summary>
    /// DTO ответа на запрос валидации токена
    /// </summary>
    public class ValidateTokenResponse
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Список ролей
        /// </summary>
        public IEnumerable<string> Roles { get; set; }
    }
}