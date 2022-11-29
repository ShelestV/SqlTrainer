namespace SqlTrainer.UserService.Presentation.Dtos;

public sealed class LoginDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}