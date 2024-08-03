using Rpg.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Monsters;
public class Monster : PlayerEntity
{
    [Required]
    public MonsterType Type { get; set; }
}
