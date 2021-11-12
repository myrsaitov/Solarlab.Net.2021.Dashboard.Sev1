namespace Sev1.UserFiles.Contracts.Contracts.YandexDisk.Responses
{
    /// <summary>
    /// DTO ответа на запрос URI на загрузку в облако
    /// </summary>
    public sealed class GetUploadUriResponse
    {
        /// <summary>
        /// Гиперссылка
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Templated { get; set; }
    }
}