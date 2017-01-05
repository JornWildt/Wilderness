using Wilderness.Game.Core;

namespace Wilderness.Game.Blueprint.Movement
{
  public class RandomMovementComponent : Component
  {
    public RandomMovementComponent(EntityId entityId)
      : base(entityId)
    {
    }


    public override string ToString()
    {
      return "IsRandom";
    }
  }
}
