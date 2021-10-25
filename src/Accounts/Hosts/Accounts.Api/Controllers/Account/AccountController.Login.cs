using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Identity;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="request">Логин (e-mail) и пароль</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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