using Rpg.Domain.Adventures;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Battles;
public class Battle
{
    [Required]
    public Adventure Adventure { get; set; }


}
