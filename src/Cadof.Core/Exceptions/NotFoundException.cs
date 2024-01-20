using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadof.Core.Exceptions;
public class NotFoundException : ArgumentException
{
    public NotFoundException(string? message) : base(message)
    {
    }
}
