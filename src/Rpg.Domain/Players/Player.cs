using Rpg.Domain.Shared;
using Rpg.Domain.Users;

namespace Rpg.Domain.Characters;

public class Player : Character
{
    public User User { get; private set; }

    public PlayerType Type { get; private set; }

    public string? BackHistory { get; set; }

    protected Player() { }
}
