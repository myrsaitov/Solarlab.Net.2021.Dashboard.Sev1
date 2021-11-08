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
        /// The raw Content-Type header of the uploaded file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The raw Content-Disposition header of the uploaded file.
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The file length in bytes.
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// The form field name from the Content-Disposition header.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The file name from the Content-Disposition header.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Массив данных файла
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; set; }
    }
}