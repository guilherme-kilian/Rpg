namespace Rpg.Domain.Shared;
public class SoftDeleteEntity : Entity
{
    public bool Deleted { get; private set; }

    public DateTimeOffset DeletedAt { get; private set; }

    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
        Deleted = true;
    }
}
