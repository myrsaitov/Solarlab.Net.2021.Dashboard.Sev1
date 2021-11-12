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
        public string BaseUri { get; set; }
    }
}