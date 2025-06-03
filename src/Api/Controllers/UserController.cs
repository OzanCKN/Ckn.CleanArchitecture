namespace Ckn.Api.Controllers;

using Ckn.  Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CreateUserCommandHandler _createUserCommandHandler;

    public UserController(CreateUserCommandHandler createUserCommandHandler)
    {
        _createUserCommandHandler = createUserCommandHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userId = await _createUserCommandHandler.Handle(command, cancellationToken);
        return CreatedAtAction(nameof(Create), new { id = userId }, userId);
    }
}
