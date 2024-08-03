using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Adventures;
using Rpg.Domain.Battles;
using Rpg.Domain.Shared;
using Rpg.Domain.Statistics;
using Rpg.Domain.Users;

namespace Rpg.Infra.Context;

public interface IDbContext
{
    DbSet<Character> Characters { get; }
    DbSet<User> Users { get; set; }
    DbSet<CharacterType> CharacterTypes { get; set; }
    DbSet<Adventure> Adventures { get; set; }
    DbSet<Battle> Battles { get; set; }
    DbSet<BattleStatistic> BattleStatistics { get; set; }
    DbSet<CharacterStatistic> CharacterStatistics { get; set; }
}
