using Cadof.Infra.Context;

namespace Cadof.Core.AppService;
public class BaseAppService
{
    private readonly IDbContext _db;

    public BaseAppService(IDbContext db)
    {
        _db = db;
    }
}
