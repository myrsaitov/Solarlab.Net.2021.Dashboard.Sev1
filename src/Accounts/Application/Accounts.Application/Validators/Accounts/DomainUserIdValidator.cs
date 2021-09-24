using FluentValidation;
using Sev1.Accounts.Application.Validators.Base;

namespace Sev1.Accounts.Application.Validators.DomainUser
{
    /// <summary>
    /// Валидатор Id категории
    /// </summary>
    public class DomainUserIdValidator : AbstractValidator<int>
    {
        public DomainUserIdValidator()
        {
            // Проверка Id
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("DomainUserId is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
