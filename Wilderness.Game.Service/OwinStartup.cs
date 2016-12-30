using log4net;
using Microsoft.Owin.Cors;
using Owin;

namespace Wilderness.Game.Service
{
  public class OwinStartup
  {
    static readonly ILog Logger = LogManager.GetLogger((typeof(OwinStartup)));


    public void Configuration(IAppBuilder app)
    {
      Logger.Debug("Starting OWIN CORS and SignalR");

      app.UseCors(CorsOptions.AllowAll);
      app.MapSignalR();
    }
  }
}
