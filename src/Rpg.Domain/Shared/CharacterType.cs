namespace Rpg.Domain.Shared;
public abstract class CharacterType : SoftDeleteEntity
{
    public string Name { get; private set; }
    public bool CanUseMagic { get; private set; }
    public ArmorType ArmorType { get; private set; }
}
