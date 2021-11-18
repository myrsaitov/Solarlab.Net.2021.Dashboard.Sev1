namespace Sev1.Accounts.Contracts.Contracts.Identity.Responses
{
    /// <summary>
    /// DTO ответа сервиса Identity при создании нового пользователя 
    /// </summary>
    public sealed class IdentityUserCreateResponse
    {
        /// <summary>
        /// Результат операции
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public string[] Errors { get; set; }
    }
}