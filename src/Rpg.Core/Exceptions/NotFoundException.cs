namespace Rpg.Core.Exceptions;
public class NotFoundException : ArgumentException
{
    public NotFoundException(string? message) : base(message)
    {
    }
}
