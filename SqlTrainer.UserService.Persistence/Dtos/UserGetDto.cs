namespace SqlTrainer.UserService.Persistence.Dtos;

public sealed class UserGetDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string HashedPassword { get; set; }
    public Guid RoleId { get; set; }
    public required string Role { get; set; } // json
    public Guid GroupId { get; set; }
    public required string Group { get; set; } // json
}