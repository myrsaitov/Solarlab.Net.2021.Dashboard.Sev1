using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Sev1.UserFiles.Application.Contracts.GetPaged;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.UserFile
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Возвращает файл по URL
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <param name="imageName">Имя файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id:int}/{imageName}")]
        public async Task<IActionResult> GetByUrl(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int id,
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            string imageName,
            CancellationToken cancellationToken)
        {
            var filePath = $"Images/Advertisements/{id}/{imageName}";
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Not found");
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                //contentType = "image/jpeg";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}