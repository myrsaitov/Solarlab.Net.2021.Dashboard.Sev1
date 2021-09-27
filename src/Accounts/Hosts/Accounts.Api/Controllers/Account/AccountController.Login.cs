using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Account;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            UserLoginRequest request,
            CancellationToken cancellationToken)
        {
            var token = await _identityService.CreateToken(
                new CreateToken.Request
                {
                    Username = request.UserName,
                    Password = request.Password
                },
                cancellationToken);

            return Ok(token);
        }

        public class UserLoginRequest
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}