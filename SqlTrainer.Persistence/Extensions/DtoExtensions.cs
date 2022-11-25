using System.Text.Json;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Dtos;

namespace SqlTrainer.Persistence.Extensions;

internal static class DtoExtensions
{
    public static User ToModel(this UserGetDto getDto)
    {
        return new User
        {
            Id = getDto.Id,
            Name = getDto.Name,
            Login = getDto.Login,
            HashPassword = getDto.HashPassword,
            GroupId = getDto.GroupId,
            RoleId = getDto.RoleId,
            Group = JsonSerializer.Deserialize<Group>(getDto.Group)!,
            Role = JsonSerializer.Deserialize<Role>(getDto.Role)!
        };
    }
}