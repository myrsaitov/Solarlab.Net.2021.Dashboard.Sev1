using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Contracts;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="request">Логин и пароль (User/User; Moderator/Moderator; Administrator/Administrator)</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
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
    }
}