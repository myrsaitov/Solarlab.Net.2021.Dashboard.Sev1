using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Contracts.Authorization;

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
        [Authorize("Admin", "Moderator")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Restore(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Restore(
                id,
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}