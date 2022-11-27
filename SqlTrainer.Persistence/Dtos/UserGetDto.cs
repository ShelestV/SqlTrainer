namespace SqlTrainer.Persistence.Dtos;

public sealed class UserGetDto : Dto
{
    public string Name { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Hash_Password { get; set; } = null!;
    public Guid Role_Id { get; set; }
    public string Role { get; set; } = null!; // json
    public Guid Group_Id { get; set; }
    public string Group { get; set; } = null!; // json
}