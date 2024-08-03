using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Adventures;
using Rpg.Domain.Attributes;
using Rpg.Domain.Battles;
using Rpg.Domain.Characters;
using Rpg.Domain.Monsters;
using Rpg.Domain.Shared;
using Rpg.Domain.Statistics;
using Rpg.Domain.Users;

namespace Rpg.Infra.Context;

public class RpgContext : DbContext, IDbContext
{
    public RpgContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CharacterType> CharacterTypes { get; set; }
    public DbSet<Adventure> Adventures { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<BattleStatistic> BattleStatistics { get; set; }
    public DbSet<CharacterStatistic> CharacterStatistics { get; set; }
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Character>()
            .HasDiscriminator<string>("discriminator")
            .HasValue<Player>(nameof(Player))
            .HasValue<Monster>(nameof(Monster));

        builder.Entity<CharacterType>()
            .HasDiscriminator<string>("discriminator")
            .HasValue<PlayerType>(nameof(PlayerType))
            .HasValue<MonsterType>(nameof(MonsterType));
    }
}
