using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;
using Wilderness.Game.MapGenerator;

namespace Wilderness.Game.Core
{
  public class GameEnvironment
  {
    public IEntityRepository EntityRepository { get; protected set; }

    public ITiledMap<TileContent> Map { get; protected set; }

    public IMessageBus MessageBus { get; protected set; }


    public GameEnvironment(IEntityRepository entityRepository, ITiledMap<TileContent> map, IMessageBus bus)
    {
      Condition.Requires(entityRepository, nameof(entityRepository)).IsNotNull();
      Condition.Requires(map, nameof(map)).IsNotNull();
      Condition.Requires(bus, nameof(bus)).IsNotNull();

      EntityRepository = entityRepository;
      Map = map;
      MessageBus = bus;
    }
  }
}
