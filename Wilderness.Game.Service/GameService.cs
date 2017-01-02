using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Topshelf;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Assemblers;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Implementation;

namespace Wilderness.Game.Service
{
  public class GameService : ServiceControl
  {
    IDisposable SignalRHost { get; set; }


    public bool Start(HostControl hostControl)
    {
      SignalRHost = WebApp.Start(ServiceAppSettings.SignalRUrl);

      IEntityRepository state = new InMemoryEntityRepository();

      Entity bear1 = BearAssembler.BuildABear("Blackie", 0, 0);
      Entity bear2 = BearAssembler.BuildABear("Brownie", 10, 10);
      Entity bear3 = BearAssembler.BuildABear("Beast", -10, -10);
      state.AddEntity(bear1);
      state.AddEntity(bear2);
      state.AddEntity(bear3);

      IMessageBus bus = new SignalRMessageBus();
      GameEnvironment env = new GameEnvironment(state, bus);
      GameEngine engine = new GameEngine(env);

      Task.Run(async () =>
      {
        await engine.RunGameLoop();
      });
      return true;
    }

    public bool Stop(HostControl hostControl)
    {
      SignalRHost.Dispose();
      return true;
    }
  }
}
