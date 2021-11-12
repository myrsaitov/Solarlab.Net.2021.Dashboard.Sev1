namespace Sev1.UserFiles.Contracts.Contracts.UserFile
{
    /// <summary>
    /// DTO ответа при загрузке файлов
    /// </summary>
    public class UserFileUploadResponse
    {
        /// <summary>
        /// Общее количество файлов в форме
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Количество успешно загруженных файлов
        /// </summary>
        public int Successful { get; set; }

        /// <summary>
        /// Количество незагруженных файлов
        /// </summary>
        public int Failed { get; set; }
    }
}