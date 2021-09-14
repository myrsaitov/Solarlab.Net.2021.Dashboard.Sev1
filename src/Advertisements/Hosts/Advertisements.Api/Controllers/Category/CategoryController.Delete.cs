using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _categoryService.Delete(new Delete.Request
            {
                Id = id
            }, cancellationToken);
            
            return NoContent();
        }
    }
}