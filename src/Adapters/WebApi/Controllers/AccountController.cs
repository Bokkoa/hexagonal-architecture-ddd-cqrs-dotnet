using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromServices] ICommandHandler<Command.CreateAccountCommand> handler,
        [FromBody] Command.CreateAccountCommand command,
        CancellationToken cancellationToken
        )
    {
        try
        {
            await handler.Handle(command, cancellationToken);
            return Ok();

        } catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
