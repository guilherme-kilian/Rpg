using AutoMapper;
using Cadof.Domain;
using Cadof.Shared.Models.Character;
using Cadof.Shared.Models.CharacterType;
using Cadof.Shared.Models.User;

namespace Cadof.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterModel>();
        CreateMap<CharacterType, CharacterTypeModel>();
        CreateMap<User, UserModel>();
    }
}
