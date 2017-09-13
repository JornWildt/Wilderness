using Castle.Windsor;
using Castle.Windsor.Installer;
using Elfisk.ECS.Core;
using Elfisk.ECS.Service;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Topshelf;
using Wilderness.Game.Blueprint;

[assembly: OwinStartup(typeof(Elfisk.ECS.Service.OwinStartup))]

namespace Wilderness.Game.Service
{
  class Program
  {
    static readonly ILog Logger = LogManager.GetLogger((typeof(Program)));

    public static IWindsorContainer CastleContainer { get; set; }

    static void Main(string[] args)
    {
      XmlConfigurator.Configure();
      Logger.Debug("**************************************************************************************");
      Logger.Debug("Starting game service");
      Logger.Debug("**************************************************************************************");

      CastleContainer = new WindsorContainer();
      CastleContainer.Install(FromAssembly.This());

      GameInitializer.Initialize(CastleContainer.Resolve<IEntityRepository>());

      HostFactory.Run(c =>
      {
        c.Service(s => new ServiceControlWithErrorHandling(new GameService(CastleContainer), Logger));
        c.StartManually();
      });
    }
  }
}
