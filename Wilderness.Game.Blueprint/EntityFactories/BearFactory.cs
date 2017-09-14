using System.Windows;
using Elfisk.ECS.Core;
using Elfisk.ECS.Core.Components;
using Wilderness.Game.Blueprint.Movement;
using Wilderness.Game.Blueprint.Physics;
using Wilderness.Game.Blueprint.Rendering;

namespace Wilderness.Game.Blueprint.EntityFactories
{
  public static class BearFactory
  {
    public static Entity BuildABear(string name, double x, double y)
    {
      EntityId id = EntityId.NewId();

      return new Entity(
        id,
        new IComponent[4]
        {
          new NameComponent(id, name),
          new PhysicsComponent(id, new Point(x,y), new Vector(1, 1)),
          new RandomMovementComponent(id),
          new VisualComponent(id, "B")
        });
    }
  }
}
