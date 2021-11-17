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
    }
}