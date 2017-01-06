namespace Wilderness.Game.Core
{
  public interface IGameLoopEvent
  {
    void Invoke(GameEnvironment environment);
  }
}
