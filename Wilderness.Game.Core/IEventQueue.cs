using System;

namespace Wilderness.Game.Core
{
  public interface IEventQueue
  {
    void Enqueue(Action a);
  }
}
