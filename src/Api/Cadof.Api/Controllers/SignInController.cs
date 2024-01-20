using Cadof.Core.AppService;
using Cadof.Core.Exceptions;
using Cadof.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Cadof.Api.Controllers;

[Route("v1/signin")]
[ApiController]
public class SignInController 
{
    private readonly SignInManager<User> _signIn;
    private readonly UserManager<User> _user;

    public SignInController(SignInManager<User> signIn, UserManager<User> user)
    {
        _signIn = signIn;
        _user = user;
    }

    [HttpPost]
    public async Task<User> SignIn(string email, string password)
    {
        var auth = await _signIn.PasswordSignInAsync(email, password, true, false);

        if (!auth.Succeeded)
            throw new AuthenticationFailedException("LoginFailed");

        return await _user.FindByEmailAsync(email) ?? throw new NotFoundException("UserNotFound");
    }
}
