using System;
using System.Windows;
using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Systems
{
  public static class RandomMovementSystem
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
