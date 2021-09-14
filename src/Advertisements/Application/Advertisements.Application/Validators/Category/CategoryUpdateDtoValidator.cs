using FluentValidation;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Validators.Base;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    public class CategoryUpdateDtoValidator : NullReferenceAbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("CategoryCreateDto is null!");

            // Id категории
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("Id не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

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
