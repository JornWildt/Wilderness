namespace Wilderness.Game.Core.Common
{
  public class RenderMessage
  {
    public string SpriteId { get; set; }

    public string Texture { get; set; }

    public int X { get; set; }

    public int Y { get; set; }


    public override string ToString()
    {
      return $"Render {Texture} at ({X};{Y})";
    }
  }
}
