using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wilderness.Game.Web.Models;

namespace Wilderness.Game.Web.Controllers
{
  public class PlayController : Controller
  {
    public ActionResult Index()
    {
      // FIXME: Hard coded URLs!
      var model = new PlayViewModel
      {
        SignalRUrl = "http://localhost:8080/signalr",
        SignalRHubUrl = "http://localhost:8080/signalr/hubs"
      };

      return View(model);
    }
  }
}