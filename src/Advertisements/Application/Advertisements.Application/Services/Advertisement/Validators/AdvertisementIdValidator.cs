using FluentValidation;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Validators
{
    /// <summary>
    /// Валидатор Id объявления
    /// </summary>
    public class AdvertisementIdValidator : AbstractValidator<int?>
    {
        public AdvertisementIdValidator()
        {
            // Проверка Id
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementId is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}