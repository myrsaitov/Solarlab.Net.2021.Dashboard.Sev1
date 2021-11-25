using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.AppServices.Contracts.User.Requests
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
        [Required]
        [StringLength(36, ErrorMessage = "Длина UserId должна быть 36 символов")]
        public string Id { get; set; }

        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина UserName не должна превышать 30 символов")]
        [MinLength(5, ErrorMessage = "Минимальная длина UserName не должна быть меньше 5 символов")]
        public string UserName { get; set; }

        /// <summary>
        /// E-mail пользователя
        /// </summary>
        [Required]
        [MaxLength(254, ErrorMessage = "Максимальная длина E-mail не должна превышать 254 символов")]
        [MinLength(5, ErrorMessage = "Минимальная длина E-mail не должна быть меньше 5 символов")]
        public string Email { get; set; }

        /// <summary>
        /// Телефонный номер пользователя
        /// </summary>
        [Required]
        [MaxLength(15, ErrorMessage = "Максимальная длина номера телефона 15 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина номера телефона не должна быть меньше 4 символов")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Максимальная длина Password не должна превышать 50 символов")]
        [MinLength(8, ErrorMessage = "Минимальная длина Password не должна быть меньше 8 символов")]
        public string Password { get; set; }

        // Необязательные поля

        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина имени не должна превышать 30 символов")]
        [MinLength(1, ErrorMessage = "Минимальная длина имени не должна быть меньше 1 символ")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина фамилии не должна превышать 30 символов")]
        [MinLength(1, ErrorMessage = "Минимальная длина фамилии не должна быть меньше 1 символ")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина отчества не должна превышать 30 символов")]
        [MinLength(1, ErrorMessage = "Минимальная длина отчества не должна быть меньше 1 символ")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        [MaxLength(100, ErrorMessage = "Максимальная длина адреса не должна превышать 100 символов")]
        [MinLength(10, ErrorMessage = "Минимальная длина адреса не должна быть меньше 10 символов")]
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [Range(1, 100_000_000_000, ErrorMessage = "Значение RegionId должно быть от 1 до 100_000_000_000")]
        public int? RegionId { get; set; }
    }
}