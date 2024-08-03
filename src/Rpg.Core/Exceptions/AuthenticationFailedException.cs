using System.Security.Authentication;

namespace Rpg.Core.Exceptions;
public class AuthenticationFailedException : AuthenticationException
{
    public AuthenticationFailedException(string? message) : base(message)
    {
    }
}
