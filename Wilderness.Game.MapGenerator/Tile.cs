namespace Wilderness.Game.MapGenerator
{
  public struct Tile<T>
    where T : struct
  {
    public int X { get; set; }

    public int Y { get; set; }

    public TileType Type { get; set; }

    public T Content { get; set; }


    public Tile(T content)
      : this(null, content)
    {
    }


    public Tile(TileType type, T content)
    {
      X = 0;
      Y = 0;
      Type = type;
      Content = content;
    }
  }
}
