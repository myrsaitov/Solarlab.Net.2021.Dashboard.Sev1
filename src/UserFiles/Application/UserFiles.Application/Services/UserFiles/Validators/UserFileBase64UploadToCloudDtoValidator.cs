using FluentValidation;
using Sev1.UserFiles.Contracts.Contracts.UserFile;
using Sev1.UserFiles.AppServices.Services.Validators.Base;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Validators
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class UserFileBase64UploadToCloudDtoValidator : NullReferenceAbstractValidator<UserFileBase64UploadRequest>
    {
        public UserFileBase64UploadToCloudDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("UserFileBase64CreateDto is null!");

            // Id объявления, к которому относятся файлы
            RuleFor(x => x.ContentBase64)
                .NotNull()
                .NotEmpty().WithMessage("ContentBase64 не заполнен!");
        }
    }
}