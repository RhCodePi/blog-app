using BlogApp.Application.DTOs.User;
using FluentValidation;

namespace BlogApp.Application.Validators
{
    public class RegistrationValidator : AbstractValidator<CreateUserDTO>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("You must enter your email")
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.Username)
                .NotNull().WithMessage("This field cannot be empty")
                .MinimumLength(3).WithMessage("Username length more than 3 character")
                .MaximumLength(50).WithMessage("Username length less than 50 character ");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("This field cannot empty");

            RuleFor(x => x.PasswordConfirm)
                .NotNull().WithMessage("This field cannot empty")
                .Equal(x => x.Password).WithMessage("Please confirm your password.");
        }
    }
}
