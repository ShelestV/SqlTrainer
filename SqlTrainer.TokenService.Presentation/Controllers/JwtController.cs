using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationResults;
using OperationResults.Web.Extensions;
using SqlTrainer.TokenService.Presentation.Dtos;
using SqlTrainer.TokenService.Presentation.Helpers;

namespace SqlTrainer.TokenService.Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public sealed class JwtController : Controller
{
    private readonly IJwtService jwtService;
    private readonly ILoginService loginService;

    public JwtController(IJwtService jwtService, ILoginService loginService)
    {
        this.jwtService = jwtService;
        this.loginService = loginService;
    }

    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var loginResult = await this.loginService.LoginAsync(dto.Login, dto.Password);
        if (!loginResult.IsCorrect())
            return loginResult.ToActionResult();
        
        return this.jwtService.Generate(loginResult.Result).ToActionResult();
    }
}
