using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.Contracts.ApiClients.YandexDisk
{
    /// <summary>
    /// API-клиент Яндекс-Диска
    /// </summary>
    public interface IYandexDiskApiClient
    {
        /// <summary>
        /// Загружает файл в облако
        /// </summary>
        /// <param name="data">Файл</param>
        /// <returns></returns>
        Task<string> Upload(IFormFile data);

        /// <summary>
        /// Загружает файл в облако
        /// </summary>
        /// <param name="data">Файл</param>
        /// <returns></returns>
        Task<string> UploadBase64(UserFileBase64UploadRequest data);
    }
}