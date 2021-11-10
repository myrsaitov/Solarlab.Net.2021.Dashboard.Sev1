namespace Sev1.Accounts.Contracts.Contracts.User
{
    /// <summary>
    /// DTO ответа при запросе пользователя
    /// </summary>
    public class UserResponseDto
    {
        /// <summary>
        /// Никнейм
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Путь к фото пользователя
        /// </summary>
        public string UserPicPath { get; set; }
    }
}