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
        /// <param name="request">Файлы с формы</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("upload-base64")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UploadUserFilesBase64ToCloud(
            [FromBody]
            List<UserFileBase64UploadRequest> request,
            CancellationToken cancellationToken)
        {
            // Определяем URI хоста (для загрузки в БД или FS)
            var baseUri = string.Format(
                        "{0}://{1}",
                        HttpContext.Request.Scheme, HttpContext.Request.Host);

            return Ok(await _userFileService.UploadUserFilesBase64ToCloud(
                baseUri,
                request, 
                cancellationToken));
        }
    }
}