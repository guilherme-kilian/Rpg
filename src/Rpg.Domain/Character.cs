using Cadof.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Cadof.Domain;

public class Character : SoftDeleteEntity
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
