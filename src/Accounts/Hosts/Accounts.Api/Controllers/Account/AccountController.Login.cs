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
        /// <param name="request">Логин и пароль [alex_1]{"eMail": "user1@mail.ru","password": "Zuse123!@#$%^()1"}  [sidorov_2]{ "eMail": "user2@mail.ru","password": "Zuse123!@#$%^()2"}  [ivanov_3]{ "eMail": "user3@mail.ru","password": "Zuse123!@#$%^()3"}  [vas_andr_4]{ "eMail": "user4@mail.ru","password": "Zuse123!@#$%^()4"}  [petr_ivanov_5]{ "eMail": "user5@mail.ru","password": "Zuse123!@#$%^()5"}  [moderator]{"eMail": "moderator@mail.ru","password": "Zadm123!@#$%^()"}  [administrator]{"eMail": "administrator@mail.ru","password": "Zadm123!@#$%^()"}</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("login")]
        public async Task<IActionResult> Login(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserLoginRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.Login(
                request,
                cancellationToken));
        }
    }
}