using FluentValidation;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Validators.Base;
using Sev1.Advertisements.Application.Validators.Tag;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    public class AdvertisementCreateDtoValidator : NullReferenceAbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementCreateDto is null!");

            // Название объявления
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty().WithMessage("Title не заполнен!")
                .Matches("[A-Z][a-z]*")
                .MaximumLength(100);

            // Текст объявления
            RuleFor(x => x.Body)
                .NotNull()
                .NotEmpty().WithMessage("Body не заполнен!")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[+!@#$%^&*]).{6,20}")
                .MinimumLength(5)
                .MaximumLength(1000);

            // Цена
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty().WithMessage("Price не заполнен!")
                .InclusiveBetween(0, decimal.MaxValue);

            // Id категории
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty().WithMessage("CategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Пользователь Id
            RuleFor(x => x.OwnerId)
                .NotNull()
                .NotEmpty().WithMessage("OwnerId не заполнен!");

            // Проверка массива строк TagBodies
            RuleForEach(x => x.TagBodies).SetValidator(new TagBodyValidator());
        }
    }
}
