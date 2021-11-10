using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Contracts.Contracts.User;
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
            var userId = await _userService.Register(
                new UserRegisterDto
                {
                    //TODO mapper
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    PhoneNumber = request.PhoneNumber
                },
                cancellationToken);
            //TODO update controller!
            return Created($"api/v1/account/{userId}", new { });
        }
    }
}