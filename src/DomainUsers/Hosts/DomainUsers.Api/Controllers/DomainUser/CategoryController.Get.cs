using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.DomainUsers.Application.Contracts.GetPaged;

namespace Sev1.DomainUsers.Api.Controllers.DomainUser
{
    public partial class DomainUserController
    {
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _domainUserService.GetPaged(new GetPagedRequest
            {
                PageSize = request.PageSize,
                Page = request.Page
            }, cancellationToken); ;

            return Ok(result);
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {

            var found = await _domainUserService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}