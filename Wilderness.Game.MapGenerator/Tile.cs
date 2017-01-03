namespace Wilderness.Game.MapGenerator
{
  public struct Tile<T>
    where T : struct
  {
    public int X { get; private set; }

    public int Y { get; private set; }

    public TileType Type { get; private set; }

    public T Content { get; private set; }


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
