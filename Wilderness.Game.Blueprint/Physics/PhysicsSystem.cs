using System;
using System.Threading.Tasks;
using Wilderness.Game.Core;

namespace Wilderness.Game.Blueprint.Physics
{
  public class PhysicsSystem : ISystem
  {
    #region Dependencies

    public IEntityRepository Entities { get; set; }

    #endregion


    public Task Update(GameEnvironment environment)
    {
      foreach (var moveable in Entities.GetComponents<PhysicsComponent>())
      {
        moveable.Position += moveable.Velocity;
        Console.WriteLine(moveable.Position + " / " + moveable.Velocity);
      }

      return Task.CompletedTask;
    }
  }
}
