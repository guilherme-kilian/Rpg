using Rpg.Domain.Shared;

namespace Rpg.Domain.Characters;
public class CharacterType : PlayerTypeEntity
{
    public string Name { get; set; }

    protected CharacterType()
    {
    }
}
