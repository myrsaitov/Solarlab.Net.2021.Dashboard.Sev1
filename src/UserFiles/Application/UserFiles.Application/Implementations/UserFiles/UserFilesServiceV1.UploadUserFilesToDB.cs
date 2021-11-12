using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Contracts.Contracts.UserFile;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using System.Linq;
using Sev1.UserFiles.Application.Exceptions;
using Sev1.UserFiles.Application.Validators.UserFile;
using System.IO;
using sev1.UserFiles.Contracts.Enums;
using Sev1.UserFiles.Application.Exceptions.Domain;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Загрузить файл в базу данных
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileUploadResponse> UploadUserFilesToDb(
            UserFileUploadDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFileUploadToDbDtoValidator();
            var result = await validator.ValidateAsync(model);
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
                    model.AdvertisementId,
                    userId);
            if (!validated)
            {
                throw new NoRightsException("Не достаточно прав!");
            }

            // Загружаем файлы в базу данных

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
            foreach (var file in model.Files)
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
                        AdvertisementId = model.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.DataBase,
                        IsDeleted = false
                    };

                    // Cчитываем переданный файл в массив байтов
                    using var binaryReader = new BinaryReader(file.OpenReadStream());
                    // И добавляем в карточку файла
                    userFile.Content = binaryReader.ReadBytes((int)file.Length);

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
                Total = model.Files.Count,
                Successful = successful,
                Failed = failed
            };
        }
    }
}