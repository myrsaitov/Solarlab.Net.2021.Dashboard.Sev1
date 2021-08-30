using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Category.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.API.Controllers.Category
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
            
            return NoAdvertisement();
        }
    }
}