using sev1.UserFiles.Contracts.Enums;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Responses
{
    public sealed class UserFileGetResponse
    {
        /// <summary>
        /// Внешняя ссылка на файл
        /// </summary>
        public string FilePath { get; set; }

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

        /// <summary>
        /// Когда загружен
        /// </summary>
        public string CreatedAt { get; set; }
    }
}