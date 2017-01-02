using System.Web.Mvc;
using Wilderness.Game.Web.Models;

namespace Wilderness.Game.Web.Controllers
{
  public class PlayController : Controller
  {
    public ActionResult Index()
    {
      var model = new PlayViewModel
      {
        SignalRUrl = WebAppSettings.SignalRBaseUrl,
        SignalRHubUrl = WebAppSettings.SignalRBaseUrl + "/hubs"
      };

      return View(model);
    }
  }
}