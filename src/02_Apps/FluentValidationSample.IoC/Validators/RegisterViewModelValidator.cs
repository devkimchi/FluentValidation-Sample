using FluentValidation;
using FluentValidationSample.WebApp.Models;

namespace FluentValidationSample.WebApp.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel2>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Password).NotNull().Length(6, 100);
            RuleFor(x => x.ConfirmPassword).NotNull().Equal(x => x.Password);
        }
    }
}