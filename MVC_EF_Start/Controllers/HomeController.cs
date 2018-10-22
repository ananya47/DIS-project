using Microsoft.AspNetCore.Mvc;

namespace MVC_EF_Start.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}