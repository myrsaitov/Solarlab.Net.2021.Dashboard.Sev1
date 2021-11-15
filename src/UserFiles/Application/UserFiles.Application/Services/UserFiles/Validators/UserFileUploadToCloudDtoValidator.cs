using FluentValidation;
using Sev1.UserFiles.Contracts.Contracts.UserFile;
using Sev1.UserFiles.AppServices.Services.Validators.Base;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Validators
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class UserFileUploadToCloudDtoValidator : NullReferenceAbstractValidator<UserFileUploadRequest>
    {
        public UserFileUploadToCloudDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("UserFileCreateDto is null!");

            // Id объявления, к которому относятся файлы
            RuleFor(x => x.AdvertisementId)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Проверка наличия файлов
            RuleFor(x => x.Files.Count)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Не должно быть URI
            RuleFor(x => x.BaseUri)
                .Null();
        }
    }
}