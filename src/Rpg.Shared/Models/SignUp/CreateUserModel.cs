using System.ComponentModel.DataAnnotations;

namespace Rpg.Shared.Models.SignUp;

public class CreateUserModel
{
    [StringLength(100, MinimumLength = 5)]
    public required string Name { get; set; }

    [StringLength(100, MinimumLength = 5)]
    public string UserName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(200, MinimumLength = 5)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
