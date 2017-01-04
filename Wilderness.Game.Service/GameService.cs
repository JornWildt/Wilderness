using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Topshelf;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Assemblers;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Components;
using Wilderness.Game.Core.Implementation;
using Wilderness.Game.MapGenerator;

namespace Wilderness.Game.Service
{
  public class GameService : ServiceControl
  {
    IDisposable SignalRHost { get; set; }

    public bool Start(HostControl hostControl)
    {
      SignalRHost = WebApp.Start(ServiceAppSettings.SignalRUrl);

      IEntityRepository entities = new InMemoryEntityRepository();

      Entity bear1 = BearFactory.BuildABear("Blackie", 0, 0);
      Entity bear2 = BearFactory.BuildABear("Brownie", 10, 10);
      Entity bear3 = BearFactory.BuildABear("Beast", -10, -10);
      entities.AddEntity(bear1);
      entities.AddEntity(bear2);
      entities.AddEntity(bear3);

      Entity player = PlayerFactory.BuildPlayer("Borg");
      entities.AddEntity(player);

      ITiledMap<TileContent> map = 
        new InMemoryTiledMap<TileContent>(
          ServiceAppSettings.MapTileSize,
          ServiceAppSettings.MapRegionSize, 
          ServiceAppSettings.MapRegionSize, 
          new PrimitiveMapGenerator<TileContent>());

      IMessageBus bus = new SignalRMessageBus();
      GameEnvironment env = new GameEnvironment(entities, map, bus);
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
