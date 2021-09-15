using FluentValidation;
using Sev1.Advertisements.Application.Contracts.GetPaged;
using Sev1.Advertisements.Application.Validators.Base;

namespace Sev1.Advertisements.Application.Validators.GetPaged
{
    /// <summary>
    /// Валидатор GetPaged
    /// </summary>
    public class GetPagedRequestValidator : NullReferenceAbstractValidator<GetPagedRequest>
    {
        public GetPagedRequestValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("GetPaged is null!");

            // Проверка Page
            RuleFor(x => x.Page)
                .NotNull()
                .NotEmpty().WithMessage("Page is null!")
                .InclusiveBetween(0, int.MaxValue);

            // Проверка PageSize
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty().WithMessage("PageSize is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
