using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.AppServices.Services.Region.Interfaces;

namespace Sev1.Advertisements.Api.Controllers.Region
{
    // Calls to this controller will only succeed
    // if the client provides Content-Type header of "application/json".
    // Otherwise a 415 (Unsupported Media Type) will be returned.
    [Consumes("application/json")]

    // Attribute routing for REST APIs
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0
    [Route("api/v1/regions")]

    // The[ApiController] attribute can be applied to
    // a controller class to enable API-specific behaviors
    [ApiController]
    public partial class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService) => _regionService = regionService;
    }
}