using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.AppServices.Services.Advertisement.UserFile;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using System.Linq;
using Sev1.UserFiles.AppServices.Services.UserFile.Validators;
using System.IO;
using sev1.UserFiles.Contracts.Enums;
using Sev1.UserFiles.Domain.Base.Exceptions;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;
using System.Collections.Generic;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Implementations
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Загрузить файл в базу данных
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileBase64UploadResponse> UploadUserFilesBase64ToCloud(
            List<UserFileBase64UploadRequest> request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFileBase64UploadToCloudDtoValidator();
            foreach (var fileRequest in request)
            {
                var result = await validator.ValidateAsync(fileRequest);
                if (!result.IsValid)
                {
                    throw new UserFileUploadDtoNotValidException(
                        result
                            .Errors
                            .Select(x => x.ErrorMessage)
                            .ToString());
                }
            }

            // Возвращаем Id пользователя
            var userId = _userProvider.GetUserId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new NoRightsException("Нет прав добавить файл!");
            }

            // Считыватем перечень разрешенных типов файлов из конфига "appsettings.json"
            var AllowedFileExtensions = _configuration
                .GetSection("AllowedFileExtensions")
                .GetChildren()
                .Select(x => x.Value)
                .ToList();

            // Создаем сущность ответа на запрос
            var response = new UserFileBase64UploadResponse()
            {
                Id = new List<int?>() {}
            };

            // В цикле каждый файл по отдельности
            foreach (var fileRequest in request)
            {
                // Проверка на разрешенные для загрузки типы файлов
                if (AllowedFileExtensions.Contains(
                    Path.GetExtension(fileRequest.FileName)
                        .ToUpperInvariant()))
                {
                    // Создаем карточку файла
                    var userFile = new Domain.UserFile()
                    {
                        Name = fileRequest.Name,
                        FileName = fileRequest.FileName,
                        ContentType = fileRequest.ContentType,
                        ContentDisposition = fileRequest.ContentDisposition,
                        Length = fileRequest.Length,
                        //AdvertisementId = request.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.DataBase,
                        IsDeleted = false
                    };

                    // Сохраняем файл в облако
#if DEBUG
                    userFile.FilePath = "https://downloader.disk.yandex.ru/disk/51e39226f4af656ccabee210f7038078c7c5990928b30a16df38249d77c1ebb7/619ed1e0/SBdg01aXT8emYcX8MaHRojBeD62QqY1Ti6rVtoK4MrvMD8C3ttWrq7szNBnOFX9TV0s6G2agMy_G2hEEnBBq3A%3D%3D?uid=1130000047162420&filename=96635ee1505b9fbb57ae94bdd76620b1.jpg&disposition=attachment&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1130000047162420&fsize=42729&hid=4e40359f5e5e7939d095312f1ef7f9de&media_type=image&tknv=v2&etag=ad1e3e189367159b9ea8e3706637b7d4";
#else
                    userFile.FilePath = await _yandexDiskApiClient
                        .UploadBase64(fileRequest);
#endif

                    // Сохраняем в базе карточку файла
                    await _userFileRepository.Save(
                        userFile,
                        cancellationToken);

                    // Добавляем идентификатор файла в ответ на запрос
                    response.Id.Add(userFile.Id);

                }
            }

            return response;
        }
    }
}