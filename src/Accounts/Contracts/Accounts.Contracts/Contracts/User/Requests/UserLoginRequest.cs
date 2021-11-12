using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts.Contracts.User.Requests
{
    /// <summary>
    /// Запрос-идентификация пользователя
    /// </summary>
    public sealed class UserLoginRequest
    {
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}