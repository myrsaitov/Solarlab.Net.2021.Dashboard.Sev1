using Sev1.UserFiles.Domain.Base;

namespace Sev1.UserFiles.Domain
{
    public class UserFile : EntityMutable<int>
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Описание файла
        /// </summary>
        public string FileDescription { get; set; }

        /// <summary>
        /// Пользователь, который загрузил файл
        /// </summary>
        public string OwnerId { get; set; }
    }
}