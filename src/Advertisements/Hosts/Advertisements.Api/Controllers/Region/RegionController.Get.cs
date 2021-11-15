using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;

namespace Sev1.Advertisements.Api.Controllers.Region
{
    public partial class RegionController
    {
        /// <summary>
        /// Возвращает таги с пагинацией
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] // Get values from the query string, e.g.: ?PageSize=10&Page=0
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _regionService.GetPaged(
                new GetPagedRequest
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Возвращает регион по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор региона</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/regions/{id}"
            int? id,
            CancellationToken cancellationToken)
        {
            var found = await _regionService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}