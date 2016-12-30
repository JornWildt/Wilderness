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
    IDisposable SignalR { get; set; }


    public bool Start(HostControl hostControl)
    {
      string url = "http://localhost:8080";
      SignalR = WebApp.Start(url);

      IEntityRepository state = new InMemoryEntityRepository();

      Entity bear1 = BearAssembler.BuildABear("Blackie", 0, 0);
      Entity bear2 = BearAssembler.BuildABear("Brownie", 10, 10);
      state.AddEntity(bear1);
      state.AddEntity(bear2);

      IMessageBus bus = new SignalRMessageBus();
      GameEngine engine = new GameEngine(state, bus);
      Task.Run(async () =>
      {
        await engine.RunGameLoop();
      });
      return true;
    }

    public bool Stop(HostControl hostControl)
    {
      SignalR.Dispose();
      return true;
    }
  }
}
