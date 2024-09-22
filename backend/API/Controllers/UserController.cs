using Application.Auth.Login;
using Application.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("/register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            if (result.IsSuccess) 
                return Ok(result.Value);

            return BadRequest(result.Error?.Message ?? "An error occurred during registration.");
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Error?.Message ?? "An error occurred during registration.");
        }
    }
}
