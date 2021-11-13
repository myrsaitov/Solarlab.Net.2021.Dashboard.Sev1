using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Services.Interfaces.UserFile;
using System.Linq;
using Sev1.UserFiles.Application.Services.Validators.UserFile;
using System.IO;
using sev1.UserFiles.Contracts.Enums;
using Sev1.UserFiles.Application.Exceptions.Domain;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.Application.Services.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Загрузить файл в файловую систему сервера
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileUploadResponse> UploadUserFilesToServerFileSystem(
            UserFileUploadRequest request,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFileUploadToFileSystemDtoValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new UserFileUploadDtoNotValidException(
                    result
                        .Errors
                        .Select(x => x.ErrorMessage)
                        .ToString());
            }

            // Возвращаем Id пользователя
            var userId = _userProvider.GetUserId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new NoRightsException("Нет прав добавить файл!");
            }

            // Проверка, существует ли объявление,
            // и принадлежит ли оно текущему пользователю
            var validated = await _advertisementApiClient
                .ValidateAdvertisement(
                    request.AdvertisementId,
                    userId);
            if(!validated)
            {
                throw new NoRightsException("Не достаточно прав!");
            }

            // Загружаем файлы в файловую систему сервера

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

            // В цикле каждый файл по отдельности
            foreach (var file in request.Files)
            {
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
                        FilePath = $"{request.BaseUri}/api/v1/userfiles/{request.AdvertisementId.ToString()}/{file.FileName}",

                    AdvertisementId = request.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.FileSystem,
                        IsDeleted = false
                    };

                    var filePath = Path.Combine(
                        @"UserFilesData",
                        @"Advertisements",
                        request.AdvertisementId.ToString(),
                        file.FileName);

                    new FileInfo(filePath).Directory?.Create();

                    await using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);

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
            };
        }
    }
}