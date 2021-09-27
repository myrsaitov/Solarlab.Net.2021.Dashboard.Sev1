using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Contracts.User;

namespace Sev1.Accounts.Api.Controllers.Account
{
    public partial class AccountController
    {
        public sealed class UserRegisterRequest
        {
            [Required]
            [MaxLength(30, ErrorMessage = "Максимальная длина логина не должна превышать 30 символов")]
            public string UserName { get; set; }

            [Required]
            [MaxLength(100, ErrorMessage = "Максимальная длина Email не должна превышать 100 символов")]
            public string Email { get; set; }

            [Required]
            [MaxLength(30, ErrorMessage = "Максимальная длина имени не должна превышать 30 символов")]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(30, ErrorMessage = "Максимальная длина фамилии не должна превышать 30 символов")]
            public string LastName { get; set; }

            [MaxLength(30, ErrorMessage = "Максимальная длина отчества не должна превышать 30 символов")]
            public string MiddleName { get; set; }

            [Required]
            public string Password { get; set; }
        }

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