using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Characters;

namespace Rpg.Infra.Context;

public interface IDbContext
{
    DbSet<Character> Characters { get; }
    DbSet<CharacterType> CharacterTypes { get; }
}
