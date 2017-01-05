using System.Threading.Tasks;
using System.Windows;
using Wilderness.Game.Blueprint.EntityFactories;
using Wilderness.Game.Blueprint.Physics;
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
          component.Position = new Point(component.Position.X + 12, component.Position.Y + 12);

          Entity explosion = ExplosionFactory.BuildExplosion(component.Position);
          environment.QueuedActions.Enqueue(() => Entities.AddEntity(explosion));
        }
      }

      return Task.CompletedTask;
    }
  }
}
