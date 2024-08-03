using Rpg.Domain.Attributes;
using Rpg.Domain.Shared;

namespace Rpg.Domain.Weapons;
public class Weapon : SoftDeleteEntity
{
    public double Damage { get; set; }
    public Stats? AdditionalStats { get; set; }
}
