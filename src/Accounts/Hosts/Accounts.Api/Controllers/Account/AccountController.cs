using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Interfaces.Account;

namespace Sev1.Accounts.Api.Controllers.Account
{
    [Route("api/v1/accounts")]
    [ApiController]
    //[Authorize]
    public partial class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) => _accountService = accountService;
    }
}