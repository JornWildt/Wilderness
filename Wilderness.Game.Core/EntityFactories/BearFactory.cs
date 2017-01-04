using System.Windows;
using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Assemblers
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
