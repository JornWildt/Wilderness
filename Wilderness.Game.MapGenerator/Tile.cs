namespace Wilderness.Game.MapGenerator
{
  public struct Tile<T>
    where T : struct
  {
    public int X { get; set; }

    public int Y { get; set; }

    public T Content { get; set; }
  }
}
