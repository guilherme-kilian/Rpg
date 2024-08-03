namespace Rpg.Shared.Models.User;
public class UserModel
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
}
