using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.UserFiles.AppServices.Services.Validators.Base
{
    /// <summary>
    /// Базовый валидатор с функционалом NullArgumentException
    /// </summary>
    /// <typeparam name="T">Класс объекта для валидации</typeparam>
    public class NullReferenceAbstractValidator<T> : AbstractValidator<T>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? Task.FromResult(new ValidationResult(new[] { new ValidationFailure(context.ToString(), "Request cannot be null", "Error") }))
                : base.ValidateAsync(context);
        }
    }
}
