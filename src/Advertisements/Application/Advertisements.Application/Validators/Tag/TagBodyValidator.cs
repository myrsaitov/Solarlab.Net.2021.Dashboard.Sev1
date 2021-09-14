using FluentValidation;

namespace Sev1.Advertisements.Application.Validators.Tag
{
    public class TagBodyValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Валидатор одного TagBody
        /// </summary>
        public TagBodyValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .Matches("[a-zA-Z0-9_]*")
                .MaximumLength(50);
        }
    }
}
