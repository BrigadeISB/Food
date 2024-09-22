using Application.Core;
using Application.Users.Login;
using MediatR;

namespace Application.Auth.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<LoginReply>>;
}
