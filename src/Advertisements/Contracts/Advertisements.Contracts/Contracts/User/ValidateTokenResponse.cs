using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.User
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
