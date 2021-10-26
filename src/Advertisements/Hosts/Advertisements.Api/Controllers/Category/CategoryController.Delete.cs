using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Delete(
                HttpContext.Request.Headers["Authorization"],
                id,
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}