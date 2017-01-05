using System.Windows;
using Wilderness.Game.Core;

namespace Wildernes.Game.Blueprint.Physics
{
  public class PhysicsComponent : Component
  {
    public Point Position { get; set; }

    public Vector Velocity { get; set; }

    public PhysicsComponent(EntityId entityId, Point position, Vector velocity)
      : base(entityId)
    {
      Position = position;
      Velocity = velocity;
    }


    public override string ToString()
    {
      return $"Pos: {Position}, V: {Velocity}";
    }
  }
}
