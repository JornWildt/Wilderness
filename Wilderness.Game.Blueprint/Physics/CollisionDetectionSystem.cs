using System;
using System.Threading.Tasks;
using System.Windows;
using Wilderness.Game.Blueprint.EntityFactories;
using Wilderness.Game.Core;
using Wilderness.Game.Core.GameEvents;
using Wilderness.Game.MapGenerator;
using Wilderness.Game.MapGenerator.TileTypes;

namespace Wilderness.Game.Blueprint.Physics
{
  public class CollisionDetectionSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }
    public ITiledMap<TileContent> Map { get; set; }
    public IGameLoopEventQueue EventQueue { get; set; }

    #endregion


    static Random Randomizer = new Random();


    public Task Update(GameEnvironment environment)
    {
      foreach (var component in Entities.GetComponents<PhysicsComponent>())
      {
        if (component.Velocity.X != 0 && component.Velocity.Y != 0
            && Map[component.Position.X, component.Position.Y].Type == ForrestTile.Instance)
        {
          Entity explosion = ExplosionFactory.BuildExplosion(component.Position);
          EventQueue.Enqueue(new ActionEvent(() => Entities.AddEntity(explosion)));

          // Change direction
          component.Velocity = new Vector(component.Velocity.Y, -component.Velocity.X);
          component.Position = 
            new Point(
              component.Position.X - 12 + Randomizer.Next(24), 
              component.Position.Y - 12 + Randomizer.Next(24));
        }
      }

      return Task.CompletedTask;
    }
  }
}
