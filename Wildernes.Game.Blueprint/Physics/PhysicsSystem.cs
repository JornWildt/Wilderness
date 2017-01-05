using System;
using Wilderness.Game.Core;

namespace Wildernes.Game.Blueprint.Physics
{
  public class PhysicsSystem : ISystem
  {
    public void Update(GameEnvironment environment)
    {
      foreach (var moveable in environment.EntityRepository.GetComponents<PhysicsComponent>())
      {
        moveable.Position += moveable.Velocity;
        Console.WriteLine(moveable.Position + " / " + moveable.Velocity);
      }
    }
  }
}
