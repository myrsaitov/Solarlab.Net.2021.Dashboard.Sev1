using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Contracts.Category;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator", "Moderator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            CategoryCreateDto model, 
            CancellationToken cancellationToken)
        {
            var response = await _categoryService.Create(
                model, 
                cancellationToken);

            return Created($"api/v1/categories/{response}", new { });
        }
    }
}