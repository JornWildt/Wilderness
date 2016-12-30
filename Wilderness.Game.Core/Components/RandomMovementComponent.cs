using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilderness.Game.Core.Components
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
