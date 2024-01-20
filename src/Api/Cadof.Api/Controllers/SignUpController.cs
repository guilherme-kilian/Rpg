using Cadof.Core.Exceptions;
using Cadof.Domain;
using Cadof.Shared.Models.SignUp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cadof.Api.Controllers;

[Route("v1/signup")]
[ApiController]
public class SignUpController
{
    private readonly UserManager<User> _userManager;

    public SignUpController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<User> SignUp(CreateUserModel create)
    {
        var user = new User(create.Email, create.Name, create.UserName);

        var auth = await _userManager.CreateAsync(user, create.Password);

        if (!auth.Succeeded)
            throw new AuthenticationFailedException("SignUpFailed");

        return user;
    }
}
