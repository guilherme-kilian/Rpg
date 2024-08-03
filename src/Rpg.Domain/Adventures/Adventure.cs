using Rpg.Domain.Characters;
using Rpg.Domain.Shared;
using Rpg.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Adventures;
public class Adventure : SoftDeleteEntity
{
    [Required]
    public string Name { get; private set; }

    [Required]
    public User Master { get; private set; }

    [Required]
    public List<Player> Players { get; private set; }

    public AdventureConfig Configuration { get; private set; }

    protected Adventure() { }
}
