using System;
using System.Windows;
using Wildernes.Game.Blueprint.Physics;
using Wilderness.Game.Core;

namespace Wildernes.Game.Blueprint.Movement
{
  public class RandomMovementSystem : ISystem
  {
    static Random Randomizer = new Random();


    public static void Update(GameEnvironment environment)
    {
      foreach (var mover in environment.EntityRepository.GetComponents<RandomMovementComponent,PhysicsComponent>())
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
        else if (r == 3)
        {
          mover.Item2.Velocity = new Vector(v.Y, v.X);
        }
      }
    }
  }
}
