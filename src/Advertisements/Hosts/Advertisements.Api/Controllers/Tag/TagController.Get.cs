using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;

namespace Sev1.Advertisements.Api.Controllers.Tag
{
    public partial class TagController
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
            var result = await _tagService.GetPaged(
                new GetPagedRequest
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);

            return Ok(result);
        }
    }
}