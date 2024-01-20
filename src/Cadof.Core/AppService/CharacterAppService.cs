using Cadof.Infra.Context;

namespace Cadof.Core.AppService;
public class CharacterAppService : BaseAppService
{
    public CharacterAppService(IDbContext db) : base(db)
    {
    }
}
