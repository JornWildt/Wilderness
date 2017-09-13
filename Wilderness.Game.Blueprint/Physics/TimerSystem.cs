using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elfisk.ECS.Core;

namespace Wilderness.Game.Blueprint.Physics
{
  public class TimerSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }
    public IGameLoopEventQueue EventQueue { get; set; }

    #endregion


    public Task Update(GameEnvironment environment)
    {
      // FIXME: there must surely be a better timer system than this!

      DateTime now = DateTime.Now; ;
      foreach (var item in Entities.GetComponents<TimedComponent>())
      {
        item.Refresh(Entities, EventQueue, now);
      }

      return Task.CompletedTask;
    }
  }
}
