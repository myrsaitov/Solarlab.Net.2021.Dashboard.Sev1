﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Api.Controllers.Tag
{
    public partial class TagController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _tagService.GetPaged(
                new GetPagedRequest
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);

            return Ok(result);
        }
    }
}