using Microsoft.AspNetCore.Mvc;

namespace PierresBakery.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}