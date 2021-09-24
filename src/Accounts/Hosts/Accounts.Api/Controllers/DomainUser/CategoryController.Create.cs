using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.DomainUser;

namespace Sev1.Accounts.Api.Controllers.DomainUser
{
    public partial class DomainUserController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] DomainUserCreateDto model, 
            CancellationToken cancellationToken)
        {
            var response = await _domainUserService.Create(
                model, 
                cancellationToken);

            return Created($"api/v1/categories/{response}", new { });
        }
    }
}