using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpDelete("{id:int}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _advertisementService.Delete(new Delete.Request
            {
                Id = id
            }, cancellationToken);
            
            return NoContent();
        }
    }
}