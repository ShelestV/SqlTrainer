namespace SqlTrainer.Persistence.Dtos;

public sealed class UserGetDto : Dto
{
    public string Name { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public Guid RoleId { get; set; }
    public string Role { get; set; } = null!; // json
    public Guid GroupId { get; set; }
    public string Group { get; set; } = null!; // json
}