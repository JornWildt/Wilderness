using System;
using System.Collections.Generic;
using CuttingEdge.Conditions;

namespace Wilderness.Game.Core
{
  public class GameEnvironment
  {
    public IDependencyContainer DependencyContainer { get; protected set; }

    public Queue<Action> QueuedActions { get; set; } = new Queue<Action>();


    public GameEnvironment(IDependencyContainer dependencies)
    {
      Condition.Requires(dependencies, nameof(dependencies)).IsNotNull();

      DependencyContainer = dependencies;
    }
  }
}
