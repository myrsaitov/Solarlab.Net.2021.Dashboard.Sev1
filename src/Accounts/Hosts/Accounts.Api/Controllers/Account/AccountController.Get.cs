using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            var found = await _accountService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}