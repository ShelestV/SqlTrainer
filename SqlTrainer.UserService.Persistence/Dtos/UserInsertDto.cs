using System.ComponentModel.DataAnnotations;

namespace SqlTrainer.UserService.Persistence.Dtos;

internal class UserInsertDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string HashPassword { get; set; }
    public Guid RoleId { get; set; }
    public Guid GroupId { get; set; }
    public required string FaceImage { get; set; }
    public double Rate { get; set; }
}
