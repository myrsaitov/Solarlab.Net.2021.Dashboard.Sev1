using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts.Contracts.User.Requests
{
    /// <summary>
    /// Запрос на изменение роли
    /// </summary>
    public sealed class UserRoleChangeRequest
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [Required]
        [StringLength(36, ErrorMessage = "Длина UserId должна быть 36 символов")]

        public string UserId { get; set; }

        /// <summary>
        /// Роль, которую добавить или удалить
        /// </summary>
        [Required]
        [MaxLength(15, ErrorMessage = "Максимальная длина Role не должна превышать 15 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина Role не должна быть меньше 4 символов")]
        public string Role { get; set; }
    }
}