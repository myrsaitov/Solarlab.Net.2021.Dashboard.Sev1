using FluentValidation;
using Sev1.UserFiles.AppServices.Services.Validators.Base;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.AppServices.Services.Validators.GetPaged
{
    /// <summary>
    /// Валидатор GetPaged
    /// </summary>
    public class UserFileGetPagedRequestValidator : NullReferenceAbstractValidator<UserFileGetPagedRequest>
    {
        public UserFileGetPagedRequestValidator()
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