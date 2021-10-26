using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Возвращает категории с пагинацией
        /// </summary>
        /// <param name="request">Запрос на пагинацию</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedRequest request, 
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
        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {

            var found = await _categoryService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}