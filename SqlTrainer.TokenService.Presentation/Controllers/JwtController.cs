using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.TokenService.Presentation.Dtos;
using SqlTrainer.TokenService.Presentation.Helpers;

namespace SqlTrainer.TokenService.Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public sealed class JwtController : Controller
{
    private readonly IJwtService jwtBusinessLogic;
    private readonly IUserBusinessLogic userBusinessLogic;

    public JwtController(IJwtService jwtBusinessLogic, IUserBusinessLogic userBusinessLogic)
    {
        this.jwtBusinessLogic = jwtBusinessLogic;
        this.userBusinessLogic = userBusinessLogic;
    }

    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var users = await userBusinessLogic.GetByLoginAsync(dto.Login);

        var user = users.Result.ToArray()[0];

        if (user is null && user!.HashPassword != dto.Password)
            return BadRequest("Incorrect login or password");

        var token = this.jwtBusinessLogic.Generate(user);

        return Ok(token.Result);
    }
}
