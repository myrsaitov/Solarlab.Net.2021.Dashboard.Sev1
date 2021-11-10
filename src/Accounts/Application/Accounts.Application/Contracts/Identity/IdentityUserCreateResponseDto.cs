namespace Sev1.Accounts.Application.Contracts.Identity
{
    /// <summary>
    /// DTO ответа сервиса Identity при создании нового пользователя 
    /// </summary>
    public sealed class IdentityUserCreateResponseDto
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