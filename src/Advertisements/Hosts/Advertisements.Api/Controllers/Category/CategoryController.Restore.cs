using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
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