using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Contracts.GetPaged;

namespace Sev1.UserFiles.Application.Interfaces.UserFile
{
    public interface IUserFileService
    {
        /// <summary>
        /// Загружает файл в файловую систему сервера
        /// </summary>
        /// <param name="model">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToServerFileSystem(
            UserFileUploadDto model, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Загружает файл в файловую БД 
        /// </summary>
        /// <param name="model">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToDb(
            UserFileUploadDto model,
            CancellationToken cancellationToken);

        /// <summary>
        /// Загружает файл в облачное хранилище 
        /// </summary>
        /// <param name="model">Модель DTO файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileUploadResponse> UploadUserFilesToCloud(
            UserFileUploadDto model,
            CancellationToken cancellationToken);

        /// <summary>
        /// Помечает файл удаленным
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Убирает пометку об удалении файла
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает файл по Id
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<UserFileDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список файлов с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedUserFileResponse> GetPaged(
            GetPagedUserFileRequest request, 
            CancellationToken cancellationToken);
    }
}