using FluentValidation;
using Sev1.Advertisements.AppServices.Services.Validators.Base;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;

namespace Sev1.Advertisements.AppServices.Services.Validators.Category
{
    /// <summary>
    /// Валидатор DTO при создании категории
    /// </summary>
    public class CategoryCreateRequestValidator : NullReferenceAbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateRequestValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("CategoryCreateDto is null!");

            // Название категории
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Name не заполнен!")

                // Протестировать тут: https://regex101.com/
                // Тест: "Транспорт", "Мебель", "Food", "Computers"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "a-zA-Z": диапазон латиницы;
                .Matches(@"^[а-яА-ЯёЁa-zA-Z]+$")
                .MaximumLength(100);

            // ParentCategoryId категории
            RuleFor(x => x.ParentCategoryId)
                .NotNull()
                .NotEmpty().WithMessage("ParentCategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
