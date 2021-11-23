using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="jsonString">DTO-модель, переданная через FormData</param>
        /// <param name="files">Файлы в FormData</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator","Moderator","User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromForm] string jsonString,
            [FromForm] List<IFormFile> files,
            CancellationToken cancellationToken)
        {
            var request = JsonConvert
                .DeserializeObject<AdvertisementCreateRequest>(jsonString);

            return Ok(await _advertisementService.Create(
                request,
                files,
                cancellationToken));
        }
    }
}