using FluentValidation;

namespace Sev1.Advertisements.AppServices.Services.Tag.Validators
{
    /// <summary>
    /// Валидатор одного TagBody
    /// </summary>
    public class TagBodyValidator : AbstractValidator<string>
    {
        public TagBodyValidator()
        {
            RuleFor(x => x)
                .NotNull()

                // Протестировать тут: https://regex101.com/
                // Тест: "утята", "котята", "3_коровы", "трактор"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "\w": символы латиницы, цифры и подчеркивание;
                .Matches(@"^[а-яА-ЯёЁ\w]+$")
                .MaximumLength(50);
        }
    }
}