using FluentValidation;
using Sev1.DomainUsers.Application.Contracts.DomainUser;
using Sev1.DomainUsers.Application.Validators.Base;

namespace Sev1.DomainUsers.Application.Validators.DomainUser
{
    /// <summary>
    /// Валидатор DTO при обновлении категории
    /// </summary>
    public class DomainUserUpdateDtoValidator : NullReferenceAbstractValidator<DomainUserUpdateDto>
    {
        public DomainUserUpdateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("DomainUserCreateDto is null!");

            // Id категории
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("Id не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Название категории
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Name не заполнен!")
                
                // The bracketed characters [a-zA-Z0-9] mean that any letter(regardless of case) or digit will match.
                // The * (asterisk) following the brackets indicates that the bracketed characters occur 0 or more times.
                .Matches("[a-zA-Z0-9]*")
                .MaximumLength(100);

            // ParentDomainUserId категории
            RuleFor(x => x.ParentDomainUserId)
                .NotNull()
                .NotEmpty().WithMessage("ParentDomainUserId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
