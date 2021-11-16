using System.Collections.Generic;

namespace Sev1.Accounts.Contracts.Contracts.Identity.Responses
{
    /// <summary>
    /// DTO ответа сервиса Identity при создании нового пользователя 
    /// </summary>
    public sealed class IdentityUserCreateTokenResponse
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