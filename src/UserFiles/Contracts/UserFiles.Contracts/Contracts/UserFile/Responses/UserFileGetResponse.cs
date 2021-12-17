using Sev1.UserFiles.Contracts.Enums;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Responses
{
    public sealed class UserFileGetResponse
    {
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Внешняя ссылка на файл
        /// </summary>
        public string FilePath { get; set; }
    }
}