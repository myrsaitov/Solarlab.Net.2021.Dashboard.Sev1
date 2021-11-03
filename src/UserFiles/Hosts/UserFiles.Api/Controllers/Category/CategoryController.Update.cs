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
        /// Редактирование категории
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator", "Moderator")]
        [HttpPut("update")] // TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            CategoryUpdateDto model, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Update(
                model,
                cancellationToken);

            return NoContent();
        }
    }
}