using System.Web.Mvc;

namespace Wilderness.Game.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return RedirectToAction("chat");
    }


    public ActionResult Chat()
    {
      return View();
    }
  }
}
