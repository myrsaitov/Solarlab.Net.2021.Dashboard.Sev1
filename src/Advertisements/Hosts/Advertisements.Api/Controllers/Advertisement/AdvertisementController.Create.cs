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
            [FromBody] AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Получаем JWT-токен из headers
            //var accessToken = HttpContext.Request.Headers["Authorization"];
            // Получаем userId текущего пользователя по токену
            //var currentUserId = await _userService.GetCurrentUserId(accessToken, cancellationToken);
            // Если пользователь существует, то вписываем его Id в модель и
            //model.OwnerId = currentUserId;


            await _advertisementService.Create(
                HttpContext.Request.Headers["Authorization"],
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}