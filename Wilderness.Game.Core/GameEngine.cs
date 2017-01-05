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
        while (Environment.QueuedActions.Count > 0)
          Environment.QueuedActions.Dequeue()();

        foreach (ISystem system in Systems)
          await system.Update(Environment);

        await Task.Delay(500);
      }
    }
  }
}
