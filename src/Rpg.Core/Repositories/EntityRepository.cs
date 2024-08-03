using Microsoft.EntityFrameworkCore;
using Rpg.Domain.Shared;

namespace Rpg.Core.Repositories;
public static class EntityRepository
{
    public static IQueryable<SoftDeleteEntity> Active(this IQueryable<SoftDeleteEntity> query) => query.Where(q => !q.Deleted);

    public static IQueryable<Entity> GetById(this IQueryable<Entity> query, int id) => query.Where(q => q.Id == id);

    public static async Task<T> FirstOrErrorAsync<T>(this IQueryable<T> query) => await query.FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(T));
}
