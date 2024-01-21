using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadof.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
[Authorize]
public class TestController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}
