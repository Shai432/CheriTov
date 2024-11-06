using Microsoft.AspNetCore.Mvc;
using ChariTov;
using ChariTov.Services;
using ChariTov.DataModels;
using System.Data;
using ChariTov.Models;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthinticationService _authinticationService;

    public AccountController(IUserService userService, IAuthinticationService tokenService)
    {
        _userService = userService;
        _authinticationService = tokenService;
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] SignIn model)
    {
        var user = await _userService.GetUserByNameAsync(model.UserName);
        if (user == null || !_userService.VerifyPassword(user.PasswordHash, model.Password))
            return Unauthorized();

        var token = _authinticationService.GenerateToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] SignUp userRegistration)
    {
        var user = await _userService.GetUserByNameAsync(userRegistration.UserName);
        if (user != null)
        {
            return BadRequest($"Invalid UserName: the name is already exists, please choose another one.");
        }

        var newUser = new User
        {
            Name = userRegistration.UserName,
            PasswordHash = Utilities.HashPassword(userRegistration.Password),
            Roles = new List<Role> { Role.User }  // Assign default role
        };

        await _userService.CreateUserAsync(newUser);

        return Ok(new { UserRegistration = userRegistration });
    }
}