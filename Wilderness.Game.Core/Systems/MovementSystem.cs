using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Systems
{
  public class MovementSystem
  {
    public static void Update(IEntityRepository state)
    {
      foreach (var moveable in state.GetComponents<PositionComponent, VelocityComponent>())
      {
        moveable.Item1.X += moveable.Item2.Dx;
        moveable.Item1.Y += moveable.Item2.Dy;
      }
    }
  }
}
