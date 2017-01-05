using System.Windows;
using Wildernes.Game.Blueprint.Movement;
using Wildernes.Game.Blueprint.Physics;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Components;

namespace Wildernes.Game.Blueprint.EntityFactories
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
          new PhysicsComponent(id, new Point(x,y), new Vector(3, 3)),
          new RandomMovementComponent(id),
          new VisualComponent(id, "B")
        });
    }
  }
}
