using FluentValidation;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Validators.Base;

namespace Sev1.UserFiles.Application.Validators.UserFile
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class UserFileUploadToCloudDtoValidator : NullReferenceAbstractValidator<UserFileUploadDto>
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