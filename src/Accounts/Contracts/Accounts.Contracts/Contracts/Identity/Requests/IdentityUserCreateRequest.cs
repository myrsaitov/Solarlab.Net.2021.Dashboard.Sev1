using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MaxLength(254, ErrorMessage = "Максимальная длина E-mail не должна превышать 254 символов")]
        [MinLength(5, ErrorMessage = "Минимальная длина E-mail не должна быть меньше 5 символов")]
        public string EMail { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина UserName не должна превышать 30 символов")]
        [MinLength(5, ErrorMessage = "Минимальная длина UserName не должна быть меньше 5 символов")]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Максимальная длина Password не должна превышать 50 символов")]
        [MinLength(8, ErrorMessage = "Минимальная длина Password не должна быть меньше 8 символов")]
        public string Password { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Required]
        [MaxLength(15, ErrorMessage = "Максимальная длина Role не должна превышать 15 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина Role не должна быть меньше 4 символов")]
        public string Role { get; set; }
    }
}