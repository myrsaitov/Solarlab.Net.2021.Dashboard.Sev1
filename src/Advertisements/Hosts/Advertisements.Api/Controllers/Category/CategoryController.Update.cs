﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.Category;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpPut("update/{id:int}")] // TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] CategoryUpdateDto model, 
            CancellationToken cancellationToken)
        {
            await _categoryService.Update(
                model,
                cancellationToken);

            return NoContent();
        }
    }
}