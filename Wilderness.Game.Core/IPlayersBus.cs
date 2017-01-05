using System.Threading.Tasks;

namespace Wilderness.Game.Core
{
  public interface IPlayersBus
  {
    Task Send(string player, object msg);
  }
}
