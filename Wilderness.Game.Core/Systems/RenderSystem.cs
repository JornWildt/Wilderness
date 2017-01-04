using Wilderness.Game.Core.Common;
using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Systems
{
  public static class RenderSystem
  {
    public static void Update(GameEnvironment environment)
    {
      //foreach (var item in environment.EntityRepository.GetComponents<VisualComponent,PhysicsComponent>())
      //{
      //  var msg = new RenderMessage
      //  {
      //    SpriteId = item.Item1.EntityId.ToString(),
      //    Texture = item.Item1.Texture,
      //    X = (int)item.Item2.Position.X,
      //    Y = (int)item.Item2.Position.Y
      //  };

      //  environment.MessageBus.Publish("to-user", msg);
      //}


      foreach (var viewport in environment.EntityRepository.GetComponents<ViewPortComponent>())
      {
        viewport.Refresh(environment);
      }
    }
  }
}
