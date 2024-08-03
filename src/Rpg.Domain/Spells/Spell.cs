using Rpg.Domain.Shared;

namespace Rpg.Domain.Spells;
public class Spell : Entity
{
    public double Damage { get; set; }

    public SpellType Type { get; set; }
}

public enum SpellType
{
    Magic,
    Physical,
    Healing,
    Buff,
    Debuff,
    Summon,
}
