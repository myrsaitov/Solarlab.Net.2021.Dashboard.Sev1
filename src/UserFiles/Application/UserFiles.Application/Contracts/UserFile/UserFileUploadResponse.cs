namespace Sev1.UserFiles.Application.Contracts.UserFile
{
    /// <summary>
    /// Ответ при загрузке файлов
    /// </summary>
    public class UserFileUploadResponse
    {
        /// <summary>
        /// Количество успешно загруженных файлов
        /// </summary>
        public int UploadedSuccessful { get; set; }
        /// <summary>
        /// Количество успешно загруженных файлов
        /// </summary>
        public int SuccessfulUploaded { get; set; }

        /// <summary>
        /// Количество незагруженных файлов
        /// </summary>
        public int NotUploaded { get; set; }
    }
}