using CuttingEdge.Conditions;

namespace Wilderness.Game.Core
{
  public class GameEnvironment
  {
    public IDependencyContainer DependencyContainer { get; protected set; }


    public GameEnvironment(IDependencyContainer dependencies)
    {
      Condition.Requires(dependencies, nameof(dependencies)).IsNotNull();

      DependencyContainer = dependencies;
    }
  }
}
