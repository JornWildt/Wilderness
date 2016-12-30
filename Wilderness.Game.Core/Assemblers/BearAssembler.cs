using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Assemblers
{
  public static class BearAssembler
  {
    public static Entity BuildABear(string name, decimal x, decimal y)
    {
      EntityId id = EntityId.NewId();

      return new Entity(
        id,
        new IComponent[3]
        {
          new NameComponent(id, name),
          new PositionComponent(id, x, y),
          new VelocityComponent(id, 0.1m, 0.1m)
        });
    }
  }
}
