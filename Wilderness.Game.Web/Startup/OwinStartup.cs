using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Wilderness.Game.Web.Startup.OwinStartup))]

namespace Wilderness.Game.Web.Startup
{
  public class OwinStartup
  {
    public void Configuration(IAppBuilder app)
    {
      // Any connection or hub wire up and configuration should go here
      app.MapSignalR();
    }
  }
}
