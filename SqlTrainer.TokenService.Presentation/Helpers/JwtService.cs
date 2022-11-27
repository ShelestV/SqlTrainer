using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SqlTrainer.TokenService.Presentation.Helpers;

public class JwtService : IJwtService
{
    private readonly IConfiguration configuration;

    public JwtService(IConfiguration configuration) =>
        this.configuration = configuration;

    public IOperationResult<string> Generate(User user)
    {
        var param = ParamsFactory.CreateSimpleWithResult(GenerateToken, user);

        return OperationService.DoOperationWithResult(param);
    }

    private string GenerateToken(User user)
    {
        var claims = new List<Claim>
            {
                new("id", user.Id.ToString()),
                new("name", user.Name),
                new("role", user.Role.Name),
                new("group", user.Group.Name)
            };

        var secretKey = configuration["Key"];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
                  signingCredentials: signingCredentials,
                  claims: claims,
                  // ToDo : discuss expires time with Vova 
                  expires: DateTime.Now.AddYears(1));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}