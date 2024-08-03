using Rpg.Domain.Battles;
using Rpg.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Statistics;
public class BattleStatistic : Entity
{
    [Required]
    public Battle Battle { get; private set; }

    public List<CharacterStatistic> Characters { get; private set; }

    public double TotalDamage { get; private set; }
}
