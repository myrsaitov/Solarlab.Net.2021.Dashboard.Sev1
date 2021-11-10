using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts.Contracts.User
{
    /// <summary>
    /// DTO-запрос при идентификации
    /// </summary>
    public class UserLoginRequest
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