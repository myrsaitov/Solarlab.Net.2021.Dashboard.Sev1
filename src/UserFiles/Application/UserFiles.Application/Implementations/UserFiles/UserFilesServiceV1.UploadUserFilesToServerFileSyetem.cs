using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using System.Linq;
using Sev1.UserFiles.Contracts.Exceptions;
using Sev1.UserFiles.Application.Validators.UserFile;
using System.Collections.Generic;
using Flurl;  // NuGet Flurl.Http
using System.IO;
using UserFiles.Contracts.Enums;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Загрузить файл в файловую систему сервера
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task UploadUserFilesToServerFileSyetem(
            UserFileUploadDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFileCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new UserFileCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
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
            if(!validated)
            {
                throw new NoRightsException("Не достаточно прав!");
            }

            // Загружаем файлы

            // Перечень разрешенных типов файлов
            var AllowedExtensions = new List<string> 
                { ".JPG",
                  ".JPE",
                  ".BMP",
                  ".GIF",
                  ".PNG",
                  ".PDF" };

            // В цикле каждый файл по отдельности
            foreach (var file in model.Files)
            {
                if (AllowedExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                {
                    // TODO Применить маппер!
                    var userFile = new Domain.UserFile()
                    {
                        FileUrl = Url.Combine(
                            model.BaseUrl,
                            "api/v1/images",
                            model.AdvertisementId.ToString(),
                            file.FileName),
                        AdvertisementId = model.AdvertisementId,
                        OwnerId = userId,
                        CreatedAt = DateTime.UtcNow,
                        Storage = UserFileStorageType.FileSystem,
                        IsDeleted = false
                    };

                    var filePath = Path.Combine(
                        @"Images",
                        @"Contents",
                        model.AdvertisementId.ToString(),
                        file.FileName);

                    new FileInfo(filePath).Directory?.Create();

                    await using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);

                    // Сохраняем в базе
                    await _userFileRepository.Save(
                        userFile,
                        cancellationToken);
                }
            }
        }
    }
}