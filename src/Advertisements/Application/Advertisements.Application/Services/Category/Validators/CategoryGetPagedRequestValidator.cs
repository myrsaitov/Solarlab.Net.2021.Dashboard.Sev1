using FluentValidation;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Domain.Base.Validators;

namespace Sev1.Advertisements.AppServices.Services.Category.Validators
{
    /// <summary>
    /// Валидатор GetPaged
    /// </summary>
    public class CategoryGetPagedRequestValidator : NullReferenceAbstractValidator<GetPagedRequest>
    {
        public CategoryGetPagedRequestValidator()
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