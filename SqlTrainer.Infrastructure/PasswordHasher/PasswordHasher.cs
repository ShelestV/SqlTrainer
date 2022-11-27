using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Application.PasswordHasher;
using System.Security.Cryptography;
using System.Text;

namespace SqlTrainer.Infrastructure.PasswordHasher;

public sealed class PasswordHasher : IPasswordHasher
{
    public IOperationResult<string> HashPassword(string password)
    {
        var param = ParamsFactory.CreateSimpleWithResult(Hash, password);
        return OperationService.DoOperationWithResult(param);
    }

    private static string Hash(string password)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Convert.ToBase64String(hash);
    }
}
