using FluentValidation;
using Sev1.Accounts.AppServices.Contracts.User.Requests;

namespace Sev1.Accounts.AppServices.Services.User.Validators
{
    /// <summary>
    /// Валидация HTTP-запроса на обновление данных пользователя
    /// </summary>
    public class UpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName не заполнен!")
                .Matches("[a-zA-Z0-9_]*")
                .MinimumLength(5)
                .MaximumLength(50);
            RuleFor(x => x.FirstName)
                .Matches("[A-Z][a-z]*").WithMessage("FirstName не валидный!")
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(x => x.LastName)
                .Matches("[A-Z][a-z]*").WithMessage("LastName не валидный!")
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(x => x.MiddleName)
                .Matches("[A-Z][a-z]*").WithMessage("MiddleName не валидный!")
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}