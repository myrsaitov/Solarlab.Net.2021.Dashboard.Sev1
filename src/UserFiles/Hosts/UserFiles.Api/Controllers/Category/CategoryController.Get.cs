using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Contracts.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Contracts.GetPaged;

namespace Sev1.UserFiles.Api.Controllers.Category
{

    public partial class CategoryController
    {
        /// <summary>
        /// Возвращает категории с пагинацией
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
            var result = await _categoryService.GetPaged(new GetPagedRequest
            {
                PageSize = request.PageSize,
                Page = request.Page
            }, cancellationToken); ;

            return Ok(result);
        }

        /// <summary>
        /// Возвращает категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/advertisements/{id}"
            int id, 
            CancellationToken cancellationToken)
        {

            var found = await _categoryService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}