using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Systems;

namespace Wilderness.Game.Core
{
  public class GameEngine
  {
    protected IEntityRepository State { get; private set; }

    protected IMessageBus MessageBus { get; private set; }


    public GameEngine(IEntityRepository state, IMessageBus bus)
    {
      Condition.Requires(state, nameof(state)).IsNotNull();
      Condition.Requires(bus, nameof(bus)).IsNotNull();

      State = state;
      MessageBus = bus;
    }


    public async Task RunGameLoop()
    {
      while (true)
      {
        MovementSystem.Update(State);
        foreach (var entity in State.GetAllEntities())
          await MessageBus.Publish("game", entity.ToString());
        await Task.Delay(5000);
      }
    }
  }
}
