using Rpg.Domain.Characters;
using Rpg.Domain.Shared;

namespace Rpg.Domain.Statistics;
public class CharacterStatistic : Entity
{
    public Player Player { get; private set; }
}
