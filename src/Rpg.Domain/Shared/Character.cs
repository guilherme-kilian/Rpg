using Rpg.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Shared;

public abstract class Character : SoftDeleteEntity
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; private set; }

    [Required]
    public CharacterAttribute Attribute { get; private set; }

    public double Experience { get; private set; }
    public int Level { get; private set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public void NextLevel()
    {
        Level++;
        Experience = 0;
    }
}
