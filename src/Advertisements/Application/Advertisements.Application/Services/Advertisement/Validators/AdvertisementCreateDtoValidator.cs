using FluentValidation;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Domain.Base.Validators;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Validators
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class AdvertisementCreateRequestValidator : NullReferenceAbstractValidator<AdvertisementCreateRequest>
    {
        public AdvertisementCreateRequestValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementCreateDto is null!");

            // Название объявления
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty().WithMessage("Title не заполнен!")

                // Протестировать тут: https://regex101.com/
                // Тест: "Продаются утята, котята, 3 коровы(?) и трактор!"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "\w": символы латиницы, цифры и подчеркивание;
                // или "\s": пробел, табуляция, перенос строки;
                // или ".?!)(,:-": знаки препинания.
                .Matches(@"^[а-яА-ЯёЁ\w\s.?!)(,:-]+$")
                .MaximumLength(100);

            // Текст объявления
            RuleFor(x => x.Body)
                .NotNull()
                .NotEmpty().WithMessage("Body не заполнен!");

                // Протестировать тут: https://regex101.com/
                // Тест: "Продаются утята, котята, 3 коровы(?) и трактор!"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "\w": символы латиницы, цифры и подчеркивание;
                // или "\s": пробел, табуляция, перенос строки;
                // или ".?!)(,:-": знаки препинания.
                //.Matches(@"^[а-яА-ЯёЁ\w\s.?!)(,:-]+$")
                //.MinimumLength(5)
                //.MaximumLength(1000);

            // Цена
            RuleFor(x => x.Price)
                .NotNull()
                //.NotEmpty().WithMessage("Price не заполнен!") // Не равен 0 - не подходит
                .InclusiveBetween(0, decimal.MaxValue);

            // Id категории
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty().WithMessage("CategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Проверка массива строк TagBodies
            //RuleForEach(x => x.TagBodies).SetValidator(new TagBodyValidator());

            // Статус объявления
            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status не заполнен!");
        }
    }
}