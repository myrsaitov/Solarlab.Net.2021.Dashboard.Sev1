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
        public string UserId { get; set; }

        /// <summary>
        /// Роль, которую добавить или удалить
        /// </summary>
        [Required]
        public string Role { get; set; }
    }
}