using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Account;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        public async Task<IActionResult> Create(
            [FromBody] AccountCreateDto model, 
            CancellationToken cancellationToken)
        {
            await _accountService.Create(
                model, 
                cancellationToken);

            return Created(string.Empty, null);
        }
    }
}