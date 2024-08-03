using AutoMapper;
using Rpg.Domain.Characters;
using Rpg.Domain.Users;
using Rpg.Shared.Models.Character;
using Rpg.Shared.Models.CharacterType;
using Rpg.Shared.Models.User;

namespace Rpg.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterModel>();
        CreateMap<CharacterType, CharacterTypeModel>();
        CreateMap<User, UserModel>();
    }
}
