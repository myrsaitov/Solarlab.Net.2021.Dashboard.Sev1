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
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator","Moderator","User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserFileCreateDto model, 
            CancellationToken cancellationToken)
        {
            await _userFileService.Create(
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}