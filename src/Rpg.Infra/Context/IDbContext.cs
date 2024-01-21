using Cadof.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cadof.Infra.Context;

public interface IDbContext
{
    DbSet<Character> Characters { get; }
    DbSet<CharacterType> CharacterTypes { get; }
}
