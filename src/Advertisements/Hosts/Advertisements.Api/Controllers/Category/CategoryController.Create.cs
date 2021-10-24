using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.Category;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] CategoryCreateDto model, 
            CancellationToken cancellationToken)
        {
            var response = await _categoryService.Create(
                HttpContext.Request.Headers["Authorization"],
                model, 
                cancellationToken);

            return Created($"api/v1/categories/{response}", new { });
        }
    }
}