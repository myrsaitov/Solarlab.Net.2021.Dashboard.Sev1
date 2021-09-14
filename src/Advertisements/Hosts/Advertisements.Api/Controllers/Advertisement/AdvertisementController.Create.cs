using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.Advertisement;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        public async Task<IActionResult> Create(
            [FromBody] AdvertisementCreateDto request, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Create(
                request, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}