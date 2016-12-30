using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Topshelf;

[assembly: OwinStartup(typeof(Wilderness.Game.Service.OwinStartup))]

namespace Wilderness.Game.Service
{
  class Program
  {
    static readonly ILog Logger = LogManager.GetLogger((typeof(Program)));

    static void Main(string[] args)
    {
      XmlConfigurator.Configure();
      Logger.Debug("**************************************************************************************");
      Logger.Debug("Starting Wilderness game service");
      Logger.Debug("**************************************************************************************");

      HostFactory.Run(c =>
      {
        c.Service(s => new ServiceControlWithErrorHandling(new GameService(), Logger));
        c.StartManually();
      });
    }
  }
}
