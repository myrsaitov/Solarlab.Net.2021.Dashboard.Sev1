using System.Collections.Generic;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Responses
{
    /// <summary>
    /// DTO ответа при загрузке файлов
    /// </summary>
    public sealed class UserFileBase64UploadResponse
    {
        /// <summary>
        /// Идентификаторы загруженных файлов
        /// </summary>
        public List<int?> Id { get; set; }
    }
}