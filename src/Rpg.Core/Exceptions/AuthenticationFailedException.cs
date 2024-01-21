using System.Security.Authentication;

namespace Cadof.Core.Exceptions;
public class AuthenticationFailedException : AuthenticationException
{
    public AuthenticationFailedException(string? message) : base(message)
    {
    }
}
