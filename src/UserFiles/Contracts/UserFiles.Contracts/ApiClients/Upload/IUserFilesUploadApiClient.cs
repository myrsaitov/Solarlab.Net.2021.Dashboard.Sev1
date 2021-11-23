using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload
{
    public interface IUserFilesUploadApiClient
    {
        /// <summary>
        /// API-клиент для загрузки файлов микросервисами 
        /// </summary>
        /// <param name="advertisementId">Идентификатор объявления, которое проверяем</param>
        /// <param name="ownerId">Идентификатор владельца объявления</param>
        /// <returns></returns>
        Task Upload(
            List<IFormFile> files);
    }
}