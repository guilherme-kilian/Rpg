using Microsoft.AspNetCore.Mvc;

namespace Cadof.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index() => Redirect("/swagger");
}
