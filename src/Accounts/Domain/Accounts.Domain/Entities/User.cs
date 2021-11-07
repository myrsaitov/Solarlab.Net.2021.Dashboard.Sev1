using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain
{
    /// <summary>
    /// Доменный пользователь
    /// </summary>
    public class User : EntityMutable<string>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}