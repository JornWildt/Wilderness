using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Implementation;
using Wilderness.Game.MapGenerator;
using Reg = Castle.MicroKernel.Registration;

namespace Wilderness.Game.Service
{
  internal class DependencyInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Reg.Component.For<IEntityRepository>().ImplementedBy<InMemoryEntityRepository>());
      container.Register(Reg.Component.For<IMessageBus>().ImplementedBy<SignalRMessageBus>());

      ITiledMap<TileContent> map =
        new InMemoryTiledMap<TileContent>(
          ServiceAppSettings.MapTileSize,
          ServiceAppSettings.MapRegionSize,
          ServiceAppSettings.MapRegionSize,
          new PrimitiveMapGenerator<TileContent>());

      container.Register(Reg.Component.For<ITiledMap<TileContent>>().Instance(map));
    }
  }
}
