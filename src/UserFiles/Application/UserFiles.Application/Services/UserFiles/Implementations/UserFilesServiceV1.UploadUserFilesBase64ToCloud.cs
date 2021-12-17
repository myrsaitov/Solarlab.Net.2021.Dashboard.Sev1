using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.AppServices.Services.Advertisement.UserFile;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using System.Linq;
using Sev1.UserFiles.AppServices.Services.UserFile.Validators;
using System.IO;
using Sev1.UserFiles.Contracts.Enums;
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
        /// <param name="baseUri">Базовый URI сервера</param>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileBase64UploadResponse> UploadUserFilesBase64ToCloud(
            string baseUri,
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
                    // Генерируем имя файла
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileRequest.FileName);

                    // Создаем карточку файла
                    var userFile = new Domain.UserFile()
                    {
                        Name = fileRequest.Name,
                        FileName = newFileName,
                        ContentType = fileRequest.ContentType,
                        ContentDisposition = fileRequest.ContentDisposition,
                        Length = fileRequest.Length,
                        //AdvertisementId = request.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.DataBase,
                        IsDeleted = false
                    };


#if DEBUG
                    // Для отладки записываем файл в FS

                    // Путь в FS
                    var fsFilePath = Path.Combine(
                        @"UserFilesData",
                        newFileName);

                    // Путь в URI
                    var uriFilePath = baseUri + Path.Combine(
                        @"/api/v1/userfiles/filesystem/",
                        newFileName);
                    userFile.FilePath = uriFilePath;

                    new FileInfo(fsFilePath).Directory?.Create();

                    var file = Convert.FromBase64String(fileRequest.ContentBase64);
                    Stream fileStream = new MemoryStream(file);

                    await using var stream = new FileStream(fsFilePath, FileMode.Create);
                    await fileStream.CopyToAsync(stream);

#else
                    // Сохраняем файл в облако
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