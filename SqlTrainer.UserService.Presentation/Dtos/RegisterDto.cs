using System.ComponentModel.DataAnnotations;

namespace SqlTrainer.UserService.Presentation.Dtos;

public class RegisterDto
{
    public required string Name { get; set; }
    public required string Login { get; set; }
    [MinLength(8)]
    public required string Password { get; set; }
    public Guid RoleId { get; set; }
    public Guid GroupId { get; set; }
    // ToDo: discuss about face image
}
