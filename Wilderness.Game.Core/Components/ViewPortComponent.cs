using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CuttingEdge.Conditions;
using Wilderness.Game.Core.Common;

namespace Wilderness.Game.Core.Components
{
  public class ViewPortComponent : Component
  {
    public Point Position { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }


    public ViewPortComponent(EntityId entityId, Point pos, double width, double height)
      : base(entityId)
    {
      Condition.Requires(width, nameof(width)).IsGreaterThan(0);
      Condition.Requires(height, nameof(height)).IsGreaterThan(0);

      Position = pos;
      Width = width;
      Height = height;
    }


    public void Refresh(GameEnvironment environment)
    {
      double minX = Position.X - Width / 2;
      double minY = Position.Y - Height / 2;
      double maxX = minX + Width;
      double maxY = minY + Height;

      foreach (var item in environment.EntityRepository.GetComponents<VisualComponent, PhysicsComponent>())
      {
        if (item.Item2.Position.X >= minX && item.Item2.Position.Y >= minY && item.Item2.Position.X < maxX && item.Item2.Position.Y < maxY)
        {
          var msg = new RenderMessage
          {
            SpriteId = item.Item1.EntityId.ToString(),
            Texture = item.Item1.Texture,
            X = (int)(item.Item2.Position.X - Position.X),
            Y = (int)(item.Item2.Position.Y - Position.Y)
          };

          environment.MessageBus.Publish("to-user", msg);
        }
      }
    }
  }
}
