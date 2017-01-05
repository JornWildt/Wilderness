using System.Threading.Tasks;
using System.Windows;
using Wildernes.Game.Blueprint.Physics;
using Wilderness.Game.Core;
using Wilderness.Game.MapGenerator;
using Wilderness.Game.MapGenerator.TileTypes;

namespace Wilderness.Game.Blueprint.Physics
{
  public class CollisionDetectionSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }
    public ITiledMap<TileContent> Map { get; set; }

    #endregion


    public Task Update(GameEnvironment environment)
    {
      foreach (var component in Entities.GetComponents<PhysicsComponent>())
      {
        if (Map[component.Position.X, component.Position.Y].Type == ForrestTile.Instance)
        {
          // Change direction
          component.Velocity = new Vector(component.Velocity.Y, -component.Velocity.X);
        }
      }

      return Task.CompletedTask;
    }
  }
}
