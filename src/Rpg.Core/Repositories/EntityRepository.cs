using Cadof.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadof.Core.Repositories;
public static class EntityRepository
{
    public static IQueryable<SoftDeleteEntity> Active(this IQueryable<SoftDeleteEntity> query) => query.Where(q => !q.Deleted);

    public static IQueryable<Entity> GetById(this IQueryable<Entity> query, int id) => query.Where(q => q.Id == id);

    public static async Task<T> FirstOrErrorAsync<T>(this IQueryable<T> query) => await query.FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(T));
}
