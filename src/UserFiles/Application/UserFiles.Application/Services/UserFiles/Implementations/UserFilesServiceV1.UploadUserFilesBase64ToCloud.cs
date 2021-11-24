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
            foreach (var file in request)
            {
                var result = await validator.ValidateAsync(file);
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

            // Хранит количество удачных загрузок
            var successful = 0;

            // Хранит количество неудачных загрузок
            var failed = 0;
            /*
            
            // В цикле каждый файл по отдельности
            foreach (var fileBase64 in request)
            {
                // Преобразование из base64

                var file = Convert.FromBase64String(fileBase64.ContentBase64);

                // Проверка на разрешенные для загрузки типы файлов
                if (AllowedFileExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                {
                    // Создаем карточку файла
                    var userFile = new Domain.UserFile()
                    {
                        Name = file.Name,
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        ContentDisposition = file.ContentDisposition,
                        Length = file.Length,
                        AdvertisementId = request.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.DataBase,
                        IsDeleted = false
                    };

                    // Сохраняем файл в облако
                    userFile.FilePath = await _yandexDiskApiClient.Upload(file);

                    // Сохраняем в базе карточку файла
                    await _userFileRepository.Save(
                        userFile,
                        cancellationToken);

                // Количество удачно загруженных файлов
                successful++;
                }
                else
                {
                    // Количество незагруженных файлов
                    failed++;
                }
            }

                return new UserFileUploadResponse()
            {
                Total = request.Files.Count,
                Successful = successful,
                Failed = failed
            }; */

            return new UserFileBase64UploadResponse()
            {
                Total = 1,
                Successful = 1,
                Failed = 1
            };
        }
    }
}