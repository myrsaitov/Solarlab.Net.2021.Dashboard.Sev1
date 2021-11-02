using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Contracts.Authorization;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Create(
                HttpContext.Request.Headers["Authorization"],
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}