using System.Threading.Tasks;

namespace Wilderness.Game.Core
{
  public interface ISystem
  {
    Task Update(GameEnvironment environment);
  }
}
