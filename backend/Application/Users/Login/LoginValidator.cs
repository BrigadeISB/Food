using Application.Auth.Login;
using FluentValidation;

namespace Application.Users.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email address format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        } 
    }
}
