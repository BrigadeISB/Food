using Application.Core;
using Domain.Users;
using FluentValidation;
using MediatR;

namespace Application.Auth.Register
{
    public class RegisterHandler(IUserRepository repository, IValidator<RegisterCommand> validator) : IRequestHandler<RegisterCommand, Result<RegisterReply>>
    {
        public async Task<Result<RegisterReply>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(request is null) 
                return Result<RegisterReply>.Failure(new ArgumentNullException(nameof(request)));

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
                return  Result<RegisterReply>.Failure(new ArgumentException(validationResult.Errors[0].ErrorMessage));

            var existUser = await repository.GetByEmailAsync(request.Email);
            if (existUser != null)
                return Result<RegisterReply>.Failure(new ArgumentException("User with this email already exist"));

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User(request.Email, hashedPassword, request.FirstName, request.LastName);
            await repository.AddAsync(newUser);

            var reply = new RegisterReply(request.FirstName, request.Email);

            return Result<RegisterReply>.Success(reply);
        }
    }
}
