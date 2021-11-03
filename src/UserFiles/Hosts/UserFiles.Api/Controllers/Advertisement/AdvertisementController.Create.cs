using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Contracts.Advertisement;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator","Moderator","User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            await _advertisementService.Create(
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}