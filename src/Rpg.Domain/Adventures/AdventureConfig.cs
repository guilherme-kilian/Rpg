using Rpg.Domain.Shared;

namespace Rpg.Domain.Adventures;

public class AdventureConfig : Entity
{
    public int InitialLevel { get; set; }

    public int AttributePointsPerLevel { get; set; }
}
