using System.Text.Json;

namespace SqlTrainer.UserService.Persistence.Extensions;

public static class DtoExtensions
{
    public static User ToModel(this UserGetDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Name = dto.Name,
            Login = dto.Login,
            HashedPassword = dto.HashedPassword,
            GroupId = dto.GroupId,
            RoleId = dto.RoleId,
            Group = JsonSerializer.Deserialize<Group>(dto.Group)!,
            Role = JsonSerializer.Deserialize<Role>(dto.Role)!
        };
    }
}