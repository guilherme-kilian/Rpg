using Rpg.Domain.Shared;

namespace Rpg.Domain.Attributes;
public class Stats : SoftDeleteEntity
{
    public int Intelligence { get; private set; }
    public int Charisma { get; private set; }
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Agility { get; private set; }
    public int Luck { get; private set; }
    public int Critical { get; private set; }
    public int Resistance { get; private set; }
    public int HealthPoints { get; private set; }
    public int Defense { get; private set; }
    public int Wisdom { get; private set; }
}
