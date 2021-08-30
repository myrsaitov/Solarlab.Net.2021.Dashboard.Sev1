﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Tag.Interfaces;

namespace Sev1.API.Controllers.Tag
{
    [Route("api/v1/tags")]
    [ApiController]
    [Authorize]
    public partial class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService) => _tagService = tagService;
    }
}