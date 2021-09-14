using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Validators.Base
{
    public class NullReferenceAbstractValidator<T> : AbstractValidator<T>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? Task.FromResult(new ValidationResult(new[] { new ValidationFailure(context.ToString(), "request cannot be null", "Error") }))
                : base.ValidateAsync(context);
        }
    }
}
