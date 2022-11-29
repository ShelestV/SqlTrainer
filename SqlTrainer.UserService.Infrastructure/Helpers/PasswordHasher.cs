using System.Security.Cryptography;
using System.Text;

namespace SqlTrainer.UserService.Infrastructure.Helpers;

public sealed class PasswordHasher : IPasswordHasher
{
    public IOperationResult<string> Hash(string password)
    {
        var param = ParamsFactory.CreateSimpleWithResult(DoHash, password);
        return OperationService.DoOperationWithResult(param);
    }

    private static string DoHash(string password)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }
}