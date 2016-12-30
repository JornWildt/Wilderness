using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Systems
{
  public static class PhysicsSystem
  {
    public static void Update(GameEnvironment environment)
    {
      foreach (var moveable in environment.EntityRepository.GetComponents<PhysicsComponent>())
      {
        moveable.Position += moveable.Velocity;
      }
    }
  }
}
