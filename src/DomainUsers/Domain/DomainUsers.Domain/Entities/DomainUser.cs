using Sev1.DomainUsers.Domain.Base;

namespace Sev1.DomainUsers.Domain
{
    public class DomainUser : EntityMutable<string>
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
        /// <summary>
        /// Фото пользователя (Id)
        /// </summary>
        public int UserPicId { get; set; }
    }
}