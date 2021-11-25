using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base.Entities;

namespace Sev1.Advertisements.Domain
{
    /// <summary>
    /// Доменная модель ссылки на файл пользователя
    /// </summary>
    public class UserFile : Entity<int?>
    {
        /// <summary>
        /// Идентификатор файла в БД файлов
        /// </summary>
        public int? FileId { get; set; }
        /// <summary>
        /// Идентификатор родительского объявления
        /// </summary>
        public int? AdvertisementId { get; set; }
    }
}