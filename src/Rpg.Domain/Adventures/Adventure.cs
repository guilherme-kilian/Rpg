using Rpg.Domain.Characters;
using Rpg.Domain.Shared;
using Rpg.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Domain.Adventures;
public class Adventure : SoftDeleteEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public User Master { get; set; }

    [Required]
    public List<Character> Players { get; set; }

    protected Adventure() { }
}
