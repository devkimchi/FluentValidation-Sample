using FluentValidation;
using FluentValidationSample.WebApp.Models;

namespace FluentValidationSample.WebApp.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Required")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Required")
                .Length(6, 100).WithMessage("Too short or too long");

            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage("Required")
                .Equal(x => x.Password).WithMessage("Not matched");
        }
    }
}