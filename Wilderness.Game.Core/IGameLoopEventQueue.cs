namespace Wilderness.Game.Core
{
  public interface IGameLoopEventQueue
  {
    void Enqueue(IGameLoopEvent e);

    void InvokeEvents(GameEnvironment environment);
  }
}
