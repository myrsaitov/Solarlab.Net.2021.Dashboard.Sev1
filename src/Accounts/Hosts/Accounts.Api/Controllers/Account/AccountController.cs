using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Interfaces;

namespace Sev1.Accounts.Api.Controllers.Account
{
    // Calls to this controller will only succeed
    // if the client provides Content-Type header of "application/json".
    // Otherwise a 415 (Unsupported Media Type) will be returned.
    [Consumes("application/json")]

    // Attribute routing for REST APIs
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0
    [Route("api/v1/accounts")]

    // The[ApiController] attribute can be applied to
    // a controller class to enable API-specific behaviors
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;

        public AccountController(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
        }
    }
}