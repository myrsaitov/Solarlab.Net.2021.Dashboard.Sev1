using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Interfaces.Tag;

namespace Sev1.Advertisements.Api.Controllers.Tag
{
    // Calls to this controller will only succeed
    // if the client provides Content-Type header of "application/json".
    // Otherwise a 415 (Unsupported Media Type) will be returned.
    [Consumes("application/json")]

    // Attribute routing for REST APIs
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0
    [Route("api/v1/tags")]

    // The[ApiController] attribute can be applied to
    // a controller class to enable API-specific behaviors
    [ApiController]
    public partial class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService) => _tagService = tagService;
    }
}