using System.Windows;
using Wildernes.Game.Blueprint.Physics;
using Wilderness.Game.Blueprint.Rendering;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Components;

namespace Wildernes.Game.Blueprint.EntityFactories
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
