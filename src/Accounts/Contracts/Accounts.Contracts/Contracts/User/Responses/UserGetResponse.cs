namespace Sev1.Accounts.Contracts.Contracts.User.Responses
{
    /// <summary>
    /// Ответ при запросе данных пользователя
    /// </summary>
    public class UserGetResponse
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
        /// Идентификатор региона
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}