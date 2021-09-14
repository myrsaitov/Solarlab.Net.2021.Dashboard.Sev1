using FluentValidation;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Validators.Base;
using Sev1.Advertisements.Application.Validators.Tag;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    public class CategoryCreateDtoValidator : NullReferenceAbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("CategoryCreateDto is null!");

            // Название категории
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Name не заполнен!")
                .Matches("[a-zA-Z0-9_]*")
                .MaximumLength(100);

            // ParentCategoryId категории
            RuleFor(x => x.ParentCategoryId)
                .NotNull()
                .NotEmpty().WithMessage("ParentCategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
