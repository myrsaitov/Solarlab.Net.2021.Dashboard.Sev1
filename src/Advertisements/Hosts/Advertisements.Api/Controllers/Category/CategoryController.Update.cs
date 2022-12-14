using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        /// <summary>
        /// Редактирование категории
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Authorize("Administrator", "Moderator")]
        [HttpPut("update")] // TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            CategoryUpdateRequest request, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Update(
                request,
                cancellationToken);

            return NoContent();
        }
    }
}