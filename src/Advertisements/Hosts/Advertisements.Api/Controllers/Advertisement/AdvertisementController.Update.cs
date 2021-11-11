using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.Advertisements.Application.Contracts.Advertisement;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Редактирует объявление
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("User")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            AdvertisementUpdateDto model, 
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