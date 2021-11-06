using Sev1.UserFiles.Domain.Base;
using sev1.UserFiles.Contracts.Enums;

namespace Sev1.UserFiles.Domain
{
    /// <summary>
    /// Информация о файле, который загружает пользователь
    /// </summary>
    public class UserFile : EntityMutable<int>
    {
        /// <summary>
        /// Внешняя ссылка на файл
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// Объявление, к которому относится этот файл
        /// </summary>
        public int AdvertisementId { get; set; }

        /// <summary>
        /// Пользователь, который загрузил файл
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Тип хранилища
        /// </summary>
        public UserFileStorageType Storage { get; set; }
    }
}