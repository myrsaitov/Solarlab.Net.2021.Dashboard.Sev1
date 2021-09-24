using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sev1.Accounts.Api.Controllers.DomainUser
{
    public partial class DomainUserController
    {
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            await _domainUserService.Delete(
                id,
                cancellationToken);

            //  Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty
            //  Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent response.
            return NoContent();
        }
    }
}