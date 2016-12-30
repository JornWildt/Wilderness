namespace Wilderness.Game.Core.Components
{
  public class VelocityComponent : Component
  {
    public decimal Dx { get; set; }

    public decimal Dy { get; set; }


    public VelocityComponent(EntityId entityId, decimal dx, decimal dy)
      : base(entityId)
    {
      Dx = dx;
      Dy = dy;
    }


    public override string ToString()
    {
      return $"Velocity: ({Dx},{Dy})";
    }
  }
}
