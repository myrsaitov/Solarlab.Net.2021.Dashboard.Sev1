using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Interfaces;

namespace Sev1.Advertisements.Api.Controllers.Tag
{
    [Route("api/v1/tags")]
    [ApiController]
    public partial class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService) => _tagService = tagService;
    }
}