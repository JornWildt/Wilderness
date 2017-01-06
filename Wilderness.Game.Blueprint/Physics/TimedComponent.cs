using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wilderness.Game.Core;
using Wilderness.Game.Core.GameEvents;

namespace Wilderness.Game.Blueprint.Physics
{
  public class TimedComponent : Component
  {
    // FIXME: use something faster like an integer and system ticks
    public DateTime Expires { get; protected set; }

    public TimedComponent(EntityId entityId, TimeSpan time)
      : base(entityId)
    {
      Expires = DateTime.Now + time;
    }


    public void Refresh(IEntityRepository entities, IGameLoopEventQueue queue, DateTime now)
    {
      if (now >= Expires)
      {
        queue.Enqueue(new ActionEvent(() => entities.RemoveEntity(EntityId)));
      }
    }
  }
}
