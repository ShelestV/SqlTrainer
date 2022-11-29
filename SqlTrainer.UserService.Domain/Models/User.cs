namespace SqlTrainer.UserService.Domain.Models;

public sealed class User : Model
{
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string HashedPassword { get; set; }
    public Guid RoleId { get; set; }
    public required Role Role { get; set; }
    public Guid GroupId { get; set; }
    public required Group Group { get; set; }
    public required string FaceImage { get; set; }
    public double Rate { get; set; }
}