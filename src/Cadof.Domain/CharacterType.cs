using Cadof.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadof.Domain;
public class CharacterType : SoftDeleteEntity
{
    public string Name { get; set; }

    protected CharacterType()
    {
    }
}
