using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SqlTrainer.JwtService.Infrastructure.BusinessLogics;
using SqlTrainer.UserService.Presentation.Extensions;
using Controller = SqlTrainer.Presentation.Controllers.Controller;

namespace SqlTrainer.UserService.Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public sealed class UsersController : Controller
{
    private readonly IJwtBusinessLogic jwtBusinessLogic;
    private readonly ILoginBusinessLogic loginBusinessLogic;
    private readonly IUserBusinessLogic userBusinessLogic;

    public UsersController(IJwtBusinessLogic jwtBusinessLogic, 
                    ILoginBusinessLogic loginBusinessLogic, 
                    IUserBusinessLogic userBusinessLogic)
    {
        this.jwtBusinessLogic = jwtBusinessLogic;
        this.loginBusinessLogic = loginBusinessLogic;
        this.userBusinessLogic = userBusinessLogic;
    }

    [HttpPost("/register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
    {
        var result = await this.userBusinessLogic.RegisterAsync(dto.ToModel());

        return result.ToActionResult();
    }

    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
    {
        var loginResult = await this.loginBusinessLogic.LoginAsync(dto.Login, dto.Password);
        if (!loginResult.IsCorrect())
            return loginResult.ToActionResult();

        var user = loginResult.Result;
        var claims = new Dictionary<string, string>
        {
            { "id", user.Id.ToString() },
            { "name", user.Name },
            { "role", user.Role.Name },
            { "group", user.Group.Name }
        };
        
        return this.jwtBusinessLogic.Generate(claims).ToActionResult();
    }
}