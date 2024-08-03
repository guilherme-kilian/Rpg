using Rpg.Infra.Context;

namespace Rpg.Core.AppService;
public class CharacterAppService : BaseAppService
{
    public CharacterAppService(IDbContext db) : base(db)
    {
    }
}
