using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Contracts;

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
            UserRegisterRequest request,
            CancellationToken cancellationToken)
        {
            var registrationResult = await _userService.Register(
                new Register.Request
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName
                },
                cancellationToken);

            return Created($"api/v1/account/{registrationResult.UserId}", new { });
        }
    }
}