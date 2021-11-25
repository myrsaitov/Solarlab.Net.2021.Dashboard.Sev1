using FluentValidation;
using Sev1.Accounts.Contracts.Contracts.User.Requests;

namespace Sev1.Accounts.AppServices.Services.User.Validators
{
    public class LoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.EMail)
                .NotEmpty().WithMessage("EMail не заполнен!")
                .EmailAddress().WithMessage("Адрес не валидный!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password не заполнен!")
                // Протестировать тут: https://regex101.com/
                // Опережающая (lookahead) проверка (https://learn.javascript.ru/regexp-lookahead-lookbehind)
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "(?=": is the start of a look-ahead group
                // ".*?": is a non-greedy match against anything or nothing (https://www.computerworld.com/article/2786107/regular-expression-tutorial-part-5--greedy-and-non-greedy-quantification.html)
                // "[A-Z]": is a character set containing the upper case ASCII letters A through to Z
                // ")": is the end of the look-ahead group
                // Match if the string contains:
                // "(?=.*?[A-Z])": an upper case letter,
                // "(?=.*?[a-z])": and a lower case letter,
                // "(?=.*?[0-9])": and a digit,
                // "(?=.*?[#?!@$%^&*-])": and a non-alphanumeric,
                // ".{6,20}": and consists of 6 to 20 characters.
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,20}$")
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }
}