using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Advertisement;

namespace Sev1.Accounts.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpPut("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        public async Task<IActionResult> Update(
            [FromBody] AdvertisementUpdateDto model, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Update(
                model, 
                cancellationToken);
            
            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}