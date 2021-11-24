using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    /// <summary>
    /// DTO запроса при загрузке файлов
    /// </summary>
    public sealed class UserFilesUploadRequest
    {
        /// <summary>
        /// Список файлов
        /// </summary>
        [Required]
        public List<UserFileDto> Files { get; set; }
    }
}