namespace Rpg.Domain.Shared;
public class Entity
{
    public int Id { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public Entity()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}
