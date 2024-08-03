using Rpg.Domain.Shared;

namespace Rpg.Domain.Battles;
public class BattleLog : Entity
{
    public Battle Battle { get; private set; }    
}
