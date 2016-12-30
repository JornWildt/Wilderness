using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Systems;

namespace Wilderness.Game.Core
{
  public class GameEngine
  {
    protected GameEnvironment Environment { get; private set; }


    public GameEngine(GameEnvironment environment)
    {
      Condition.Requires(environment, nameof(environment)).IsNotNull();

      Environment = environment;
    }


    public async Task RunGameLoop()
    {
      while (true)
      {
        PhysicsSystem.Update(Environment);
        RandomMovementSystem.Update(Environment);
        RenderSystem.Update(Environment);

        //foreach (var entity in Environment.EntityRepository.GetAllEntities())
        //  await Environment.MessageBus.Publish("game", entity.ToString());
        await Task.Delay(500);
      }
    }
  }
}
