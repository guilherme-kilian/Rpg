using Microsoft.AspNetCore.Identity;

namespace Rpg.Domain.Users;
public class User : IdentityUser
{
    public string Name { get; set; }

    /// <summary>
    /// for entity
    /// </summary>
    protected User() { }

    public User(string email, string name, string userName)
    {
        Email = email;
        Name = name;
        UserName = userName;
    }
}
