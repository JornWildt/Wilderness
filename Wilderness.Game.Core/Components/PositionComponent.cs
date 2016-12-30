namespace Wilderness.Game.Core.Components
{
  public class PositionComponent : Component
  {
    public decimal X { get; set; }

    public decimal Y { get; set; }


    public PositionComponent(EntityId entityId, decimal x, decimal y)
      : base(entityId)
    {
      X = x;
      Y = y;
    }


    public override string ToString()
    {
      return $"Position: ({X},{Y})";
    }
  }
}
