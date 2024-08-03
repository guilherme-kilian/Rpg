using Microsoft.AspNetCore.Mvc;

namespace Rpg.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index() => Redirect("/swagger");
}
