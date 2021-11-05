using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.UserFile
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Создает новый файл
        /// </summary>
        /// <param name="id">Id объявления, к которомы прикрепляются файлы</param>
        /// <param name="files">Файлы с формы</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int id,
            [FromForm]
            List<IFormFile> files,
            CancellationToken cancellationToken)
        {
            await _userFileService.Create(
                new UserFileCreateDto()
                {
                    BaseUrl = string.Format(
                        "{0}://{1}",
                        HttpContext.Request.Scheme, HttpContext.Request.Host), // Определяем URL хоста
                    Files = files,
                    AdvertisementId = id
                }, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}