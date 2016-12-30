using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;

namespace Wilderness.Game.Core
{
  public class GameEnvironment
  {
    public IEntityRepository EntityRepository { get; protected set; }

    public IMessageBus MessageBus { get; protected set; }


    public GameEnvironment(IEntityRepository entityRepository, IMessageBus bus)
    {
      Condition.Requires(entityRepository, nameof(entityRepository)).IsNotNull();
      Condition.Requires(bus, nameof(bus)).IsNotNull();

      EntityRepository = entityRepository;
      MessageBus = bus;
    }
  }
}
