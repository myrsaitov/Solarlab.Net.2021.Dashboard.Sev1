﻿namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Responses
{
    /// <summary>
    /// DTO ответа при загрузке файлов
    /// </summary>
    public sealed class UserFileBase64UploadResponse
    {
        /// <summary>
        /// Идентификаторы загруженных файлов
        /// </summary>
        public int?[] Id { get; set; }

        /// <summary>
        /// Общее количество файлов в форме
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// Количество успешно загруженных файлов
        /// </summary>
        public int? Successful { get; set; }

        /// <summary>
        /// Количество незагруженных файлов
        /// </summary>
        public int? Failed { get; set; }
    }
}