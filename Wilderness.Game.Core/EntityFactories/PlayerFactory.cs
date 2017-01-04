using System.Windows;
using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Assemblers
{
  public static class PlayerFactory
  {
    public static Entity BuildPlayer(string name)
    {
      EntityId id = EntityId.NewId();

      return new Entity(
        id,
        new IComponent[4]
        {
          new NameComponent(id, name),
          new ViewPortComponent(id, new Point(0,0), 100, 100),
          new PhysicsComponent(id, new Point(0,0), new Vector(0, 0)),
          new VisualComponent(id, "T1")
        });
    }
  }
}
