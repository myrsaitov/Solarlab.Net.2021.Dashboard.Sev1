using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Interfaces
{
    public interface IUserFileService
    {
        /// <summary>
        /// Загружает файл в облачное хранилище 
        /// </summary>
        /// <param name="baseUri">Базовый URI сервера</param>
        /// <param name="request">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileBase64UploadResponse> UploadUserFilesBase64ToCloud(
            string baseUri,
            List<UserFileBase64UploadRequest> request,
            CancellationToken cancellationToken);


        /// <summary>
        /// Загружает файл в файловую систему сервера
        /// </summary>
        /// <param name="request">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToServerFileSystem(
            UserFileUploadRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Загружает файл в файловую БД 
        /// </summary>
        /// <param name="request">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToDb(
            UserFileUploadRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Загружает файл в облачное хранилище 
        /// </summary>
        /// <param name="request">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToCloud(
            UserFileUploadRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Помечает файл удаленным
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Убирает пометку об удалении файла
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает файл по Id
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileGetResponse> GetById(
            int? id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список файлов с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileGetPagedResponse> GetPaged(
            UserFileGetPagedRequest request, 
            CancellationToken cancellationToken);
    }
}