using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.API.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _advertisementService.Delete(new Delete.Request
            {
                Id = id
            }, cancellationToken);
            
            return NoAdvertisement();
        }
    }
}