using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Contracts.User.Requests;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        // [HttpPost("<route>")]
        // Creates a new Microsoft.AspNetCore.Mvc.HttpPostAttribute
        // with the given route template.

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="request">Данные с формы регистрации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromBody] //[FromBody] <= "Content-Type: application/json-patch+json"
            UserRegisterRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _userService.Register(
                request,
                cancellationToken));
        }
    }
}