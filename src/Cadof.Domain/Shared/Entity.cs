using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadof.Domain.Shared;
public class Entity
{
    public int Id { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public Entity()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}
