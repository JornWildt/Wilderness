using System.Threading.Tasks;
using Elfisk.ECS.Core;

namespace Wilderness.Game.Blueprint.Rendering
{
  public class RenderSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }

    public IPlayersBus PlayersBus { get; set; }

    #endregion


    public async Task Update(GameEnvironment environment)
    {
      foreach (var viewport in Entities.GetComponents<ViewPortComponent>())
      {
        await viewport.Refresh(Entities, PlayersBus);
      }
    }
  }
}
