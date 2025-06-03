namespace Ckn.Api.Controllers;

using Ckn.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthController(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    { 
        var token = _jwtTokenGenerator.GenerateToken(
            Guid.NewGuid(),
            request.UserName,
            request.Email,
            new[] { "User" }
        );
        return Ok(new { Token = token });
    }
}

public record LoginRequest(string UserName, string Email);
