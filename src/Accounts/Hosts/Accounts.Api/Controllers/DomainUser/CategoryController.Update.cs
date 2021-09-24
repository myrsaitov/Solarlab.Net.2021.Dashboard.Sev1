using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.DomainUser;

namespace Sev1.Accounts.Api.Controllers.DomainUser
{
    public partial class DomainUserController
    {
        [HttpPut("update/{id:int}")] // TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update(
            [FromBody] DomainUserUpdateDto model, 
            CancellationToken cancellationToken)
        {
            await _domainUserService.Update(
                model,
                cancellationToken);

            return NoContent();
        }
    }
}