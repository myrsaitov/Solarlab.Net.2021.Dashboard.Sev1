using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        /// <summary>
        /// Возвращает объявления с пагинацией (и поиском)
        /// </summary>
        /// <param name="request">Запрос на пагинацию и поиск</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementService.GetPaged(
                request, 
                cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Возвращает объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpGet("{id}")]
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