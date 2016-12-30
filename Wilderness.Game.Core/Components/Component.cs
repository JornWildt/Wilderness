namespace Wilderness.Game.Core.Components
{
  public class Component : IComponent
  {
    public EntityId EntityId { get; private set; }

    public Component(EntityId entityId)
    {
      EntityId = entityId;
    }
  }
}
