using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Interfaces.Account;

namespace Sev1.Accounts.Api.Controllers.Account
{
    [Route("api/v1/advertisements")]
    [ApiController]
    //[Authorize]
    public partial class AccountController : ControllerBase
    {
        private readonly IAccountService _advertisementService;
        public AccountController(IAccountService advertisementService) => _advertisementService = advertisementService;
    }
}