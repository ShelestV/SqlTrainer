using System.Text.Json;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Dtos;

namespace SqlTrainer.Persistence.Extensions;

internal static class DtoExtensions
{
    public static User ToModel(this UserGetDto getDto)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        }; 
        
        return new User
        {
            Id = getDto.Id,
            Name = getDto.Name,
            Login = getDto.Login,
            HashPassword = getDto.Hash_Password,
            GroupId = getDto.Group_Id,
            RoleId = getDto.Role_Id,
            Group = JsonSerializer.Deserialize<Group>(getDto.Group, serializeOptions)!,
            Role = JsonSerializer.Deserialize<Role>(getDto.Role, serializeOptions)!
        };
    }
}