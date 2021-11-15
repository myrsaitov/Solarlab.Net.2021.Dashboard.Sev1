using FluentValidation;
using Sev1.Advertisements.AppServices.Services.Validators.Base;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;

namespace Sev1.Advertisements.AppServices.Services.Validators.GetPaged
{
    /// <summary>
    /// Валидатор GetPaged
    /// </summary>
    public class AdvertisementGetPagedRequestValidator : NullReferenceAbstractValidator<AdvertisementGetPagedRequest>
    {
        public AdvertisementGetPagedRequestValidator()
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

            //TODO добавить остальные поля
        }
    }
}