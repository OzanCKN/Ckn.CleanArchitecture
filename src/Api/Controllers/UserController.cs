namespace Ckn.Api.Controllers;
using Ckn.Application.Users.Commands.CreateUser;
using Ckn.Application.Users.Queries.GetUserDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = userId }, userId);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new GetUserDetailQuery(id), cancellationToken);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}
