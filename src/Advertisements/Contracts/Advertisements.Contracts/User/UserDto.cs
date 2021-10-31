using System;
using Sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.Contracts.User
{
    public class UserDto : DtoBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Идентификатор региона.
        /// </summary>
        public Guid RegionId { get; set; }
        
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
    }
}