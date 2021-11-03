using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.Advertisement
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Восстанавливает удаленный файл
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Restore(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/advertisements/{id}"
            int id, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Restore(
                id,
                cancellationToken);
            
            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}