using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.DomainUser;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.DomainUser
{
    public partial class DomainUserController
    {
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Restore(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _domainUserService.Restore(
                id,
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}