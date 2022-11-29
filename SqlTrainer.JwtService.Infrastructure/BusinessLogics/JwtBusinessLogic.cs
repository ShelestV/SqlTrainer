using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.JwtService.Infrastructure.Configurations;

namespace SqlTrainer.JwtService.Infrastructure.BusinessLogics;

public sealed class JwtBusinessLogic : IJwtBusinessLogic
{
    private readonly IJwtConfiguration configuration;

    public JwtBusinessLogic(IJwtConfiguration configuration) =>
        this.configuration = configuration;

    public IOperationResult<string> Generate(IDictionary<string, string> claims)
    {
        var param = ParamsFactory.CreateSimpleWithResult(GenerateToken, claims);
        return OperationService.DoOperationWithResult(param);
    }

    private string GenerateToken(IDictionary<string, string> dictClaims)
    {
        var claims = dictClaims.Select(claim => new Claim(claim.Key, claim.Value)).ToList();
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.SecretKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            // ToDo : discuss expires time with Vova 
            expires: DateTime.Now.AddYears(1));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}