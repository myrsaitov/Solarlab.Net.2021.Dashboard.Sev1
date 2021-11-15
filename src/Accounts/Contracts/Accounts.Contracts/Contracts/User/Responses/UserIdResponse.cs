namespace Sev1.Accounts.Contracts.Contracts.User.Responses
{
    /// <summary>
    /// DTO ответа сервиса Identity на запрос идентификатора авторизированного пользователя
    /// </summary>
    public sealed class UserIdResponse
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}