using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpDelete("{id:int}")]
        //[Authorize]
        public async Task<IActionResult> Delete(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Delete(
                id, 
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}