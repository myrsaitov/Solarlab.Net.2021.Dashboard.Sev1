using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain
{
    /// <summary>
    /// Доменный пользователь
    /// </summary>
    public class User : EntityMutable<string>
    {
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
        /// Никнейм
        /// </summary>
        public string UserName { get; set; }
    }
}