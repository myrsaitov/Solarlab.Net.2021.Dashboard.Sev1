using FluentValidation;
using Sev1.Advertisements.AppServices.Contracts.Advertisement.Requests;
using Sev1.Advertisements.AppServices.Services.Tag.Validators;
using Sev1.Advertisements.Domain.Base.Validators;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Validators
{
    /// <summary>
    /// Валидатор DTO при обновлении объявления
    /// </summary>
    public class AdvertisementUpdateStatusDtoValidator : NullReferenceAbstractValidator<AdvertisementUpdateStatusRequest>
    {
        public AdvertisementUpdateStatusDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementUpdateDto is null!");

            // Статус объявления
            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status не заполнен!");
        }
    }
}