using Rpg.Shared.Models.CharacterType;
using Rpg.Shared.Models.User;

namespace Rpg.Shared.Models.Character;
public class CharacterModel
{
    public required string Name { get; set; }
    public CharacterTypeModel CharacterType { get; set; }
    public UserModel User { get; set; }
}
