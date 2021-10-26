using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Восстанавливает удаленную категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Restore(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Restore(
                HttpContext.Request.Headers["Authorization"],
                id,
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}