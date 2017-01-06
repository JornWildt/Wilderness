using System;
using System.Threading.Tasks;
using System.Windows;
using Wilderness.Game.Blueprint.Physics;
using Wilderness.Game.Core;

namespace Wilderness.Game.Blueprint.Movement
{
  public class RandomMovementSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }

    #endregion


    static Random Randomizer = new Random();


    public Task Update(GameEnvironment environment)
    {
      foreach (var mover in Entities.GetComponents<RandomMovementComponent,PhysicsComponent>())
      {
        int r = Randomizer.Next(30);
        Vector v = mover.Item2.Velocity;

        if (r == 0)
        {
          mover.Item2.Velocity = new Vector(v.X, -v.Y);
        }
        else if (r == 1)
        {
          mover.Item2.Velocity = new Vector(-v.X, -v.Y);
        }
        else if (r == 2)
        {
          mover.Item2.Velocity = new Vector(-v.X, v.Y);
        }
      }

      return Task.CompletedTask;
    }
  }
}
