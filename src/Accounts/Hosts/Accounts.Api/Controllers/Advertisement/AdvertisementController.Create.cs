using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Advertisement;

namespace Sev1.Accounts.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        public async Task<IActionResult> Create(
            [FromBody] AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Create(
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}