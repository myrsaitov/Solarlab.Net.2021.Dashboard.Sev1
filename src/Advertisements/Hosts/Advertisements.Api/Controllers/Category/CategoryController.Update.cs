using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.Category;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Редактирование категории
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpPut("update/{id:int}")] // TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] CategoryUpdateDto model, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Update(
                HttpContext.Request.Headers["Authorization"],
                model,
                cancellationToken);

            return NoContent();
        }
    }
}