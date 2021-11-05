using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using System.Linq;
using Sev1.UserFiles.Domain.Exceptions;
using Sev1.UserFiles.Application.Validators.UserFile;
using System.Collections.Generic;
using Flurl;  // NuGet Flurl.Http
using System.IO;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Create(
            UserFileCreateDto model,
            CancellationToken cancellationToken)
        {
            /*
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
                throw new NoRightsException("Нет создателя объявления!");
            }

            // Дополняем модель - Id пользователя, который создал объявление
            //model.OwnerId = userId;

            // Дополняем модель
            var userFiles = _mapper.Map<Domain.UserFile>(model);
            userFiles.IsDeleted = false;
            userFiles.CreatedAt = DateTime.UtcNow;

            // Сохраняем в базе
            await _userFileRepository.Save(
                userFiles, 
                cancellationToken);
            */




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
                throw new NoRightsException("Нет создателя объявления!");
            }

            var ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

            foreach (var file in model.Files)
            {
                if (ImageExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                {
                    var domainFile = new Domain.UserFile()
                    {
                        FileUrl = Url.Combine(
                            model.BaseUrl,
                            "api/v1/images",
                            model.AdvertisementId.ToString(),
                            file.FileName),
                        CreatedAt = DateTime.UtcNow,
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
                }
            }
        }
    }
}