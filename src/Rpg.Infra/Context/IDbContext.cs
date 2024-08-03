using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Adventures;
using Rpg.Domain.Attributes;
using Rpg.Domain.Battles;
using Rpg.Domain.Shared;
using Rpg.Domain.Spells;
using Rpg.Domain.Statistics;
using Rpg.Domain.Users;
using Rpg.Domain.Weapons;

namespace Rpg.Infra.Context;

public interface IDbContext
{
    DbSet<Character> Characters { get; }
    DbSet<User> Users { get; }
    DbSet<CharacterType> CharacterTypes { get; }
    DbSet<Adventure> Adventures { get; }
    DbSet<Battle> Battles { get; }
    DbSet<BattleStatistic> BattleStatistics { get; }
    DbSet<CharacterStatistic> CharacterStatistics { get; }
    DbSet<AdventureConfig> AdventureConfigs { get; }
    DbSet<Stats> Stats { get; }
    DbSet<BattleLog> BattleLogs { get; }
    DbSet<Weapon> Weapons { get; }
    DbSet<Spell> Spells { get; }
}
