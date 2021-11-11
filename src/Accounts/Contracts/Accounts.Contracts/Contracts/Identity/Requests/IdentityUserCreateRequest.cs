namespace Sev1.Accounts.Contracts.Contracts.Identity.Requests
{
    /// <summary>
    /// DTO запроса сервису Identity на создание нового пользователя 
    /// </summary>
    public sealed class IdentityUserCreateRequest
    {
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
    }
}