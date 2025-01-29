using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dtos.Requests;
using Movies.Application.Services;

namespace Movies.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{

    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    
    public AuthController(IUserService userService, ILogger<AuthController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var user = _userService.GetByEmailAsync(loginRequest.Email, cancellationToken);

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUser createUser, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateAsync(createUser, cancellationToken);
        return response ? Ok(response) : BadRequest();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        return Ok();
    }
    
}