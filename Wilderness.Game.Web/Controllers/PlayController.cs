using System;
using System.Web.Mvc;
using Wilderness.Game.Web.Models;

namespace Wilderness.Game.Web.Controllers
{
  public class PlayController : Controller
  {
    public ActionResult Index()
    {
      var rootUrl = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/");

      var model = new PlayViewModel
      {
        RootUrl = rootUrl,
        SignalRUrl = WebAppSettings.SignalRBaseUrl,
        SignalRHubUrl = WebAppSettings.SignalRBaseUrl + "/hubs"
      };

      return View(model);
    }
  }
}