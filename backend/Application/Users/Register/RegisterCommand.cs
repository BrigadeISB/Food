using Application.Core;
using MediatR;

namespace Application.Auth.Register
{
    public record RegisterCommand(string Email, string FirstName, string LastName, string Password) : IRequest<Result<RegisterReply>>;
}
