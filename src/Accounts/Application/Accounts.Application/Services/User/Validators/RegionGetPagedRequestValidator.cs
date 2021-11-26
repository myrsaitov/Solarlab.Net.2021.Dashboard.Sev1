using FluentValidation;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Domain.Base.Validators;

namespace Sev1.Accounts.AppServices.Services.User.Validators
{
    /// <summary>
    /// Валидатор GetPaged
    /// </summary>
    public class UserGetPagedRequestValidator : NullReferenceAbstractValidator<UserGetPagedRequest>
    {
        public UserGetPagedRequestValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("GetPaged is null!");

            // Проверка Page
            RuleFor(x => x.Page)
                .NotNull()
                //.NotEmpty().WithMessage("Page is null!")
                .InclusiveBetween(0, int.MaxValue);

            // Проверка PageSize
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty().WithMessage("PageSize is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}