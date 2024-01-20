using Cadof.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cadof.Infra.Context;

public class CadofContext : IdentityUserContext<User>, IDbContext
{
    public CadofContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterType> CharacterTypes { get; set; }
}
