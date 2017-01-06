using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Wilderness.Game.Blueprint;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Implementation;
using Wilderness.Game.MapGenerator;
using Reg = Castle.MicroKernel.Registration;

namespace Wilderness.Game.Service
{
  public class DependencyInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Reg.Component.For<IEntityRepository>().ImplementedBy<InMemoryEntityRepository>());
      container.Register(Reg.Component.For<IPlayersBus>().ImplementedBy<SignalRPlayersBus>());
      container.Register(Reg.Component.For<IGameLoopEventQueue>().ImplementedBy<GameLoopEventQueue>());

      container.Register(
        Classes.FromAssemblyNamed("Wilderness.Game.Blueprint")
        .BasedOn<ISystem>()
        .WithService.Base());

      ITiledMap <TileContent> map =
        new InMemoryTiledMap<TileContent>(
          ServiceAppSettings.MapTileSize,
          ServiceAppSettings.MapRegionSize,
          ServiceAppSettings.MapRegionSize,
          new PrimitiveMapGenerator<TileContent>());

      container.Register(Reg.Component.For<ITiledMap<TileContent>>().Instance(map));
    }
  }
}
