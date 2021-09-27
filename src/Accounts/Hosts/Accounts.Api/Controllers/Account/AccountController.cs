using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Interfaces.Account;

namespace Sev1.Accounts.Api.Controllers.Account
{
    [Route("api/v1/accounts")]
    [ApiController]
    [AllowAnonymous]
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