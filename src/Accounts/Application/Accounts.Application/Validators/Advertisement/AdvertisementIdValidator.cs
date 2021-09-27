using FluentValidation;
using Sev1.Accounts.Application.Validators.Base;

namespace Sev1.Accounts.Application.Validators.Account
{
    /// <summary>
    /// Валидатор Id объявления
    /// </summary>
    public class AccountIdValidator : AbstractValidator<int>
    {
        public AccountIdValidator()
        {
            // Проверка Id
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AccountId is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
