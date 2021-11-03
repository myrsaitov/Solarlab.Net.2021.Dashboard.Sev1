using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Interfaces.Tag;

namespace Sev1.UserFiles.Api.Controllers.Tag
{
    [Route("api/v1/tags")]
    [ApiController]
    public partial class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService) => _tagService = tagService;
    }
}