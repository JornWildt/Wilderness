using System;
using System.Threading.Tasks;
using Elfisk.ECS.Core;
using Elfisk.ECS.Core.GameEvents;
using Wilderness.Game.Core.Common;

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


    public async Task Refresh(IEntityRepository entities, IGameLoopEventQueue queue, IPlayersBus bus, DateTime now)
    {
      if (now >= Expires)
      {
        var msg = new RemoveSpriteMessage
        {
          SpriteId = EntityId.ToString(),
        };

        await bus.Send("to-user", msg);

        queue.Enqueue(new ActionEvent(() =>
        {
          entities.RemoveEntity(EntityId);
        }));
      }
    }
  }
}
