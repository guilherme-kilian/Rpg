using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Adventures;
using Rpg.Domain.Attributes;
using Rpg.Domain.Battles;
using Rpg.Domain.Characters;
using Rpg.Domain.Monsters;
using Rpg.Domain.Shared;
using Rpg.Domain.Spells;
using Rpg.Domain.Statistics;
using Rpg.Domain.Users;
using Rpg.Domain.Weapons;

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
    public DbSet<Stats> Stats { get; set; }
    public DbSet<AdventureConfig> AdventureConfigs { get; set; }
    public DbSet<BattleLog> BattleLogs { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<Weapon> Weapons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Character>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Player>(nameof(Player))
            .HasValue<Monster>(nameof(Monster));

        builder.Entity<CharacterType>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<PlayerType>(nameof(PlayerType))
            .HasValue<MonsterType>(nameof(MonsterType));
    }
}
