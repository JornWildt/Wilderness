using System.Threading.Tasks;
using System.Windows;
using CuttingEdge.Conditions;
using Wilderness.Game.Blueprint.Physics;
using Wilderness.Game.Core;
using Wilderness.Game.Core.Common;

namespace Wilderness.Game.Blueprint.Rendering
{
  public class ViewPortComponent : Component
  {
    public Rect Box { get; set; }

    public Rect LastSentMapBoundingBox { get; set; }


    public ViewPortComponent(EntityId entityId, Point pos, double width, double height)
      : base(entityId)
    {
      Condition.Requires(width, nameof(width)).IsGreaterThan(0);
      Condition.Requires(height, nameof(height)).IsGreaterThan(0);

      Box = new Rect(pos.X, pos.Y, width, height);
    }


    public async Task Refresh(IEntityRepository entities, IPlayersBus bus)
    {
      //double minX = Position.X - Width / 2;
      //double minY = Position.Y - Height / 2;
      //double maxX = minX + Width;
      //double maxY = minY + Height;

      foreach (var item in entities.GetComponents<VisualComponent, PhysicsComponent>())
      {
        //if (item.Item2.Position.X >= minX && item.Item2.Position.Y >= minY && item.Item2.Position.X < maxX && item.Item2.Position.Y < maxY)
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

      if (LastSentMapBoundingBox.Width == 0 || !LastSentMapBoundingBox.Contains(Box.X, Box.Y))
      {
        Rect mapbox = new Rect(Box.X - Box.Width / 2, Box.Y - Box.Height / 2, Box.Width, Box.Height);
        // Send map!
        LastSentMapBoundingBox = mapbox;
      }
    }
  }
}
