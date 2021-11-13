using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    /// <summary>
    /// DTO запроса при загрузке файлов
    /// </summary>
    public sealed class UserFileUploadRequest
    {
        /// <summary>
        /// Id объявления, к которому прикрепляются файлы
        /// </summary>
        [Required]
        [Range(1, 100_000_000_000, ErrorMessage = "Значение AdvertisementId должно быть от 1 до 100_000_000_000")]
        public int AdvertisementId { get; set; }
        
        /// <summary>
        /// Список файлов
        /// </summary>
        [Required]
        public List<IFormFile> Files { get; set; }

        /// <summary>
        /// Адрес текущего сервера
        /// </summary>
        [Required]
        [MaxLength(2000, ErrorMessage = "Максимальная длина URI не должна превышать 2000")]
        public string BaseUri { get; set; }
    }
}