using Cadof.Shared.Models.CharacterType;
using Cadof.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadof.Shared.Models.Character;
public class CharacterModel
{
    public required string Name { get; set; }
    public CharacterTypeModel CharacterType { get; set; }
    public UserModel User { get; set; }
}
