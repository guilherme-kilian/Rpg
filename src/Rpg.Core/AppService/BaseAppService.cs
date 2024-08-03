using Rpg.Infra.Context;

namespace Rpg.Core.AppService;
public class BaseAppService
{
    private readonly IDbContext _db;

    public BaseAppService(IDbContext db)
    {
        _db = db;
    }
}
