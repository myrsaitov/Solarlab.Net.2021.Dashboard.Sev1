using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
    }
}