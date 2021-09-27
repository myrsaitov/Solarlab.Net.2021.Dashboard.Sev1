using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Advertisement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sev1.Accounts.Application.Contracts.GetPaged;

namespace Sev1.Accounts.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementService.GetPaged(
                request, 
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            var found = await _advertisementService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}