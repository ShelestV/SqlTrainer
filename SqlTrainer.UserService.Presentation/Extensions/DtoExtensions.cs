using SqlTrainer.UserService.Domain.Models;

namespace SqlTrainer.UserService.Presentation.Extensions;

public static class DtoExtensions
{
    public static User ToModel(this RegisterDto dto)
    { 
        return new User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            GroupId = dto.GroupId,
            RoleId = dto.RoleId,
            Login = dto.Login,
            Group = null!,
            HashedPassword = dto.Password,
            Role = null!,
            FaceImage = "default.jpg",
            Rate = 0.0
        };
    }
}
