﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.UserFiles.Application.Contracts.GetPaged;

namespace Sev1.UserFiles.Api.Controllers.UserFile
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Возвращает файл по URI
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="imageName">Имя файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id:int}/{imageName}")]
        public async Task<IActionResult> GetFromFileSystem(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int id,
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}/{imageName}"
            string imageName,
            CancellationToken cancellationToken)
        {
            // Место хранения файлов в файловой системе
            var filePath = $"UserFilesData/Advertisements/{id}/{imageName}";
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Not found");
            }

            // Определяем тип контента
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "image/jpeg";
            }

            // Считываем файл в память
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            
            // Возвращаем файл
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}