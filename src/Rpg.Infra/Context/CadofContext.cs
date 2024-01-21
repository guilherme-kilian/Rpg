using Cadof.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cadof.Infra.Context;

public class CadofContext : DbContext, IDbContext
{
    public CadofContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CharacterType> CharacterTypes { get; set; }
}
