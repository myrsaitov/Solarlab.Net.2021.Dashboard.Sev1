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
 //#if DEBUG
                    //*
                    Random rnd = new Random();
                    int picNumber = rnd.Next(1, 10);

                    switch (picNumber)
                    {
                        case 1:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/1-5.jpg";
                            break;

                        case 2:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/2-5.jpg";
                            break;

                        case 3:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/3-5.jpg";
                            break;

                        case 4:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/4-5.jpg";
                            break;

                        case 5:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/5-5.jpg";
                            break;

                        case 6:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/6-5.jpg";
                            break;

                        case 7:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/7-5.jpg";
                            break;

                        case 8:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/8-5.jpg";
                            break;

                        case 9:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/9-5.jpg";
                            break;

                        case 10:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/10-5.jpg";
                            break;

                        default:
                            userFile.FilePath = "https://vjoy.cc/wp-content/uploads/2019/07/11-5.jpg";
                            break;
                    }//*/
                   
// #else
                    //userFile.FilePath = await _yandexDiskApiClient
                    //    .UploadBase64(fileRequest);
//#endif

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