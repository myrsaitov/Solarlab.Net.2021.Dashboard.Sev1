using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sev1.Advertisements.Application.Contracts.Advertisement;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
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
            var accessToken = HttpContext.Request.Headers["Authorization"];

            await _advertisementService.Create(
                accessToken,
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}