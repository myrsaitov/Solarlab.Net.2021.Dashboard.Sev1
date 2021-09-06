﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Contracts;

namespace Sev1.Advertisements.Api.Controllers.Tag
{
    public partial class TagController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaged([FromQuery] GetPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _tagService.GetPaged(new Paged.Request
            {
                PageSize = request.PageSize,
                Page = request.Page
            }, cancellationToken);

            return Ok(result);
        }
    }
}