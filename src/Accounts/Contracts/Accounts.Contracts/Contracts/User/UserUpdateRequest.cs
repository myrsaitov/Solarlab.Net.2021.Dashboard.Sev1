using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Application.Contracts.User
{
    /// <summary>
    /// Запрос на обновление данных пользователя
    /// </summary>
    public sealed class UserUpdateRequest
    {
        // Обязательные поля

        /// <summary>
        /// Id пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина логина не должна превышать 30 символов")]
        public string UserName { get; set; }

        /// <summary>
        /// E-mail пользователя
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Максимальная длина Email не должна превышать 100 символов")]
        public string Email { get; set; }

        /// <summary>
        /// Телефонный номер пользователя
        /// </summary>
        [Required]
        [MaxLength(15, ErrorMessage = "Максимальная длина номера телефона 15 символов")]
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }

        // Необязательные поля

        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина имени не должна превышать 30 символов")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина фамилии не должна превышать 30 символов")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина отчества не должна превышать 30 символов")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        [MaxLength(100, ErrorMessage = "Максимальная длина адреса не должна превышать 100 символов")]
        public string Address { get; set; }

        /// <summary>
        /// Путь к фото пользователя
        /// </summary>
        public string UserPicPath { get; set; }
    }
}