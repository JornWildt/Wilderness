using System.Linq;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;

namespace Wilderness.Game.Core
{
  public class GameEngine
  {
    protected GameEnvironment Environment { get; private set; }

    protected ISystem[] Systems { get; set; }


    public GameEngine(GameEnvironment environment)
    {
      Condition.Requires(environment, nameof(environment)).IsNotNull();

      Environment = environment;
    }


    public async Task RunGameLoop()
    {
      Systems = Environment.DependencyContainer.ResolveAll<ISystem>().ToArray();

      while (true)
      {
        foreach (ISystem system in Systems)
          await system.Update(Environment);

          //foreach (var entity in Environment.EntityRepository.GetAllEntities())
          //  await Environment.MessageBus.Publish("game", entity.ToString());
          await Task.Delay(500);
      }
    }
  }
}
