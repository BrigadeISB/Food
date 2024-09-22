using Application.Auth.Login;
using Application.Core;
using Domain.Users;
using FluentValidation;
using MediatR;

namespace Application.Users.Login
{
    public class LoginHandler(IValidator<LoginCommand> validator, IUserRepository repository) : IRequestHandler<LoginCommand, Result<LoginReply>>
    {
        public async Task<Result<LoginReply>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return Result<LoginReply>.Failure(new ArgumentNullException(nameof(request)));

            var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            if (!validationResult.IsValid)
                return Result<LoginReply>.Failure(new ArgumentException(validationResult.Errors[0].ErrorMessage));

            User? user = null;

            if (!String.IsNullOrEmpty(request.Email))
            {
                user = await repository.GetByEmailAsync(request.Email).ConfigureAwait(false);

                if (user is null)
                    return Result<LoginReply>.Failure(new ArgumentException("Incorrect email or password"));
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user!.PasswordHash))
                return Result<LoginReply>.Failure(new ArgumentException("Incorrect email or password"));

            var result = new LoginReply(user.Email, user.FirstName);

            return Result<LoginReply>.Success(result);
        }
    }
}
