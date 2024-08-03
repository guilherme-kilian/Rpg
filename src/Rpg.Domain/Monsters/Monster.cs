using Rpg.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Monsters;
public class Monster : Character
{
    [Required]
    public MonsterType Type { get; private set; }

    public string? Picture { get; set; }

    protected Monster() { }

    public Monster(MonsterType type)
    {
        Type = type;
    }

    public string GetPicture()
    {
        if (!string.IsNullOrEmpty(Picture))
            return Picture;

        return Type.Picture;
    }
}
