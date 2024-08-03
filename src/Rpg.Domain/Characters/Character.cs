using Rpg.Domain.Shared;
using Rpg.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Characters;

public class Character : PlayerEntity
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; private set; }

    public User User { get; private set; }

    public CharacterType Type { get; private set; }

    protected Character() { }

    public Character(string name, User user, CharacterType type)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(Name));

        Name = name;
        User = user;
        Type = type;
    }
}
