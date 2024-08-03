using Rpg.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Adventures;

public class AdventureConfig : Entity
{
    public int InitialLevel { get; set; }

    public int AttributePointsPerLevel { get; set; }
}
