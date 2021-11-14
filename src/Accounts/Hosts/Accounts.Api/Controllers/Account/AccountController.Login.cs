using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User.Requests;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="request">Логин и пароль USER: {"email":"user@mail.ru","password":"Zuse123!@#$%^()"}; MODERATOR: {"email":"moderator@mail.ru","password":"Zmod123!@#$%^()"}; ADMINISTRATOR: {"email":"administrator@mail.ru","password":"Zadm123!@#$%^()"}</param>
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
                request,
                cancellationToken);

            return Ok(token);
        }
    }
}


// {"email":"user@mail.ru","password":"Zuse123!@#$%^()"} {"email":"moderator@mail.ru","password":"Zmod123!@#$%^()"} {"email":"administrator@mail.ru","password":"Zadm123!@#$%^()"}