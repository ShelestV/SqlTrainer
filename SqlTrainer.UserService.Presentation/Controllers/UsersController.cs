using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SqlTrainer.JwtService.Infrastructure.BusinessLogics;

using Controller = SqlTrainer.Presentation.Controllers.Controller;

namespace SqlTrainer.UserService.Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public sealed class UsersController : Controller
{
    private readonly IJwtBusinessLogic jwtBusinessLogic;
    private readonly ILoginBusinessLogic loginBusinessLogic;

    public UsersController(IJwtBusinessLogic jwtBusinessLogic, ILoginBusinessLogic loginBusinessLogic)
    {
        this.jwtBusinessLogic = jwtBusinessLogic;
        this.loginBusinessLogic = loginBusinessLogic;
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