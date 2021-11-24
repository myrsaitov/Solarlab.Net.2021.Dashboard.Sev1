using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload
{
    public interface IUserFilesUploadApiClient
    {
        /// <summary>
        /// API-клиент для загрузки файлов микросервисами 
        /// </summary>
        /// <param name="files">Идентификатор владельца объявления</param>
        /// <returns></returns>
        Task<UserFileBase64UploadResponse> UploadBase64(
            List<UserFileBase64UploadRequest> Files);
    }
}