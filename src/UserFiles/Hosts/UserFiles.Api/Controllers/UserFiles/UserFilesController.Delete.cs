using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.UserFile
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Удалает файл (из БД не удаляет, но помечает, что он удален)
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator","Moderator","User")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int? id, 
            CancellationToken cancellationToken)
        {
            await _userFileService.Delete(
                id, 
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}