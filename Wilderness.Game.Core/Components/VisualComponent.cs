using CuttingEdge.Conditions;

namespace Wilderness.Game.Core.Components
{
  public class VisualComponent : Component
  {
    public string Texture { get; set; }


    public VisualComponent(EntityId entityId, string texture)
      : base(entityId)
    {
      Condition.Requires(texture, nameof(texture)).IsNotNull();

      Texture = texture;
    }


    public override string ToString()
    {
      return $"[{Texture}]";
    }
  }
}
