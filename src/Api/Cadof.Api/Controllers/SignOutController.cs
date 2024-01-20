using Cadof.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cadof.Api.Controllers;

[Route("v1/signout")]

[ApiController]
public class SignOutController
{
    private readonly SignInManager<User> _signIn;

    public SignOutController(SignInManager<User> signIn)
    {
        _signIn = signIn;
    }

    [HttpPost]
    public Task SignOut() => _signIn.SignOutAsync();
}
