using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.Api.Controllers.UserFile
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Загрузить файл в файловую систему сервера
        /// </summary>
        /// <param name="id">Идентификатор объявления, к которомы прикрепляются файлы</param>
        /// <param name="files">Файлы с формы</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{id:int}/to-data-base")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UploadUserFilesToDB(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int? id,
            [FromForm]
            List<IFormFile> files,
            CancellationToken cancellationToken)
        {
            var res = await _userFileService.UploadUserFilesToDb(
                new UserFileUploadRequest()
                {
                    Files = files,
                    AdvertisementId = id
                }, 
                cancellationToken);

            return Ok(res);
        }
    }
}