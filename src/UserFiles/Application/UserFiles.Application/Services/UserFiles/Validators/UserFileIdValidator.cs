using FluentValidation;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Validators
{
    /// <summary>
    /// Валидатор Id объявления
    /// </summary>
    public class UserFilesIdValidator : AbstractValidator<int?>
    {
        public UserFilesIdValidator()
        {
            // Проверка Id
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("UserFileId is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}
