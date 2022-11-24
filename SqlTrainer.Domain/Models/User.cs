namespace SqlTrainer.Domain.Models;

public sealed class User : Model
{
    public string Name { get; set; }
    public string Logic { get; set; }
    public string HashPassword { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
}