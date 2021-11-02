using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Contracts.Authorization;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Восстанавливает удаленные объявления
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Admin", "Moderator", "User")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Restore(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Restore(
                HttpContext.Request.Headers["Authorization"],
                id,
                cancellationToken);
            
            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}