using Rpg.Domain.Adventures;
using Rpg.Domain.Monsters;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Battles;
public class Battle
{
    [Required]
    public Adventure Adventure { get; private set; }

    public List<Monster> Monsters { get; set; }
}
