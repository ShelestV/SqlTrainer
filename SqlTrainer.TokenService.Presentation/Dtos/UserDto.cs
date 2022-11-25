namespace SqlTrainer.TokenService.Presentation.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Login { get; set; } = null!;
    public Guid RoleId { get; set; }
    public string Role { get; set; } = null!;
    public Guid GroupId { get; set; }
    public string Group { get; set; } = null!;
}
