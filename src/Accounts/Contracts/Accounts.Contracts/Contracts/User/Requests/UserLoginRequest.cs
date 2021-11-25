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
        [MaxLength(254, ErrorMessage = "Максимальная длина E-mail не должна превышать 254 символа")]
        [MinLength(5, ErrorMessage = "Минимальная длина E-mail не должна быть меньше 5 символов")]
        public string EMail { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Максимальная длина Password не должна превышать 50 символов")]
        [MinLength(8, ErrorMessage = "Минимальная длина Password не должна быть меньше 8 символов")]

        public string Password { get; set; }
    }
}