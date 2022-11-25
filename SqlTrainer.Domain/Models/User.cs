namespace SqlTrainer.Domain.Models;

public sealed class User : Model
{
    public string Name { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
}