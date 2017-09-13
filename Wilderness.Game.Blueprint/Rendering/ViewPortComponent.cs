using System.Threading.Tasks;
using System.Windows;
using CuttingEdge.Conditions;
using Wilderness.Game.Blueprint.Physics;
using Elfisk.ECS.Core;
using Wilderness.Game.Core.Common;

namespace Wilderness.Game.Blueprint.Rendering
{
  public class ViewPortComponent : Component
  {
    public Rect Box { get; set; }


    public ViewPortComponent(EntityId entityId, Point pos, double width, double height)
      : base(entityId)
    {
      Condition.Requires(width, nameof(width)).IsGreaterThan(0);
      Condition.Requires(height, nameof(height)).IsGreaterThan(0);

      Box = new Rect(pos.X, pos.Y, width, height);
    }


    public async Task Refresh(IEntityRepository entities, IPlayersBus bus)
    {
      foreach (var item in entities.GetComponents<VisualComponent, PhysicsComponent>())
      {
        if (Box.Contains(item.Item2.Position))
        {
          var msg = new RenderMessage
          {
            SpriteId = item.Item1.EntityId.ToString(),
            Texture = item.Item1.Texture,
            X = (int)(item.Item2.Position.X - Box.X),
            Y = (int)(item.Item2.Position.Y - Box.Y)
          };

          await bus.Send("to-user", msg);
        }
      }
    }
  }
}
